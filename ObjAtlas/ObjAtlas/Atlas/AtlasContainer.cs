using ObjAtlas.Extensions;
using ObjAtlas.WaveFront.Containers;
using ObjAtlas.WaveFront.Mat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.Atlas
{
    public class AtlasContainer
    {
        private IList<GroupAtl> _groups;

        private ObjFile _objOriginal;
        private ObjFile _objModified;

        public AtlasContainer(string pFilename)
        {
            //load in the original file
            _objOriginal = new ObjFile();
            _objOriginal.LoadFile(pFilename);

            //clone it
            _objModified = _objOriginal.DeepClone();

            //process our individual groups
            ParseObjMaterials();
        }

        private void ParseObjMaterials()
        {
             //clear the atlas materials
            _groups = new List<GroupAtl>();

            //create a default group for textures
            var texGroup = new GroupAtl("Default" + DateTime.UtcNow.Millisecond.ToString(), true, false);

            //iterate through materials
            var ml = _objOriginal.GetMaterials();
            foreach (var m in ml)
            {
                if (m.HasTextures())
                {
                    var ta = new MaterialAtl(m.materialName,m.GetFirstTexture(),_objOriginal.folderDirectory);
                    ta.ProcessUVData(_objOriginal.GetUVMin(m.materialName), _objOriginal.GetUVMax(m.materialName));
                    texGroup.AddMaterial(ta);
                } else
                {
                    var ga = new GroupAtl(m.materialName, false, true);
                    var ta = new MaterialAtl(m.materialName);
                    ga.AddMaterial(ta);
                    _groups.Add(ga);
                }
            }

            _groups.Add(texGroup);
        }

        public string GetRootFolder()
        {
            return _objOriginal.folderDirectory;
        }
        public IList<GroupAtl> GetTexturelessMaterials()
        {
            return _groups.Where(x => x.hasTextureImages == false).ToList();
        }
        public IList<GroupAtl> GetIgnoredMaterials()
        {
            return _groups.Where(x => x.hasTextureImages == true && x.isIgnored == true).ToList();
        }
        public IList<GroupAtl> GetAtlasMaterials()
        {
            return _groups.Where(x => x.hasTextureImages == true && x.isIgnored == false).ToList();
        }

        public bool AddAtlasGroup(string pName)
        {
            pName = SanitizeAtlasGroupName(pName);
            if (!VerifyAtlasGroupName(pName))
                return false;

            GroupAtl ga = new GroupAtl(pName, true, false);
            _groups.Add(ga);
            return true;
        }
        public bool DeleteAtlasGroup( GroupAtl pGroup)
        {
            if (_groups.Count == 1)
                return false;

            //get the materials
            IList<MaterialAtl> mats = pGroup.GetMaterials();

            //remove the group
            _groups.Remove(pGroup);

            //get the first group
            var ga = _groups.First();
            foreach (var m in mats)
            {
                ga.AddMaterial(m);
            }

            return true;
        }
        public bool ChangeAtlasGroupName(string pName, GroupAtl pGroup)
        {
            pName = SanitizeAtlasGroupName(pName);
            if (!VerifyAtlasGroupName(pName, pGroup))
                return false;

            pGroup.name = pName;
            return true;
        }

        private string SanitizeAtlasGroupName(string pName)
        {
            pName = pName.Trim();
            pName = pName.Replace(" ", "");
            pName = pName.RemoveSpecialCharacters();
            return pName;
        }
        private bool VerifyAtlasGroupName(string pName, GroupAtl pGroup = null)
        {
            if (string.IsNullOrEmpty(pName))
                return false;

            if (pGroup != null)
            {
                if (_groups.Any(x => x.name.ToLowerInvariant() == pName && x != pGroup))
                    return false;
            }
            
            if (_groups.Any(x => x.GetMaterialByName(pName) != null))
                return false;

            return true;
        }
        public int GetAtlasGroupIndex(GroupAtl pGroup)
        {
            return _groups.IndexOf(pGroup);
        }
        public bool SetMaterialToGroupByIndex(int pSourceIndex, int pTargetIndex, MaterialAtl pMaterial)
        {
            if (pSourceIndex < 0 || pTargetIndex < 0)
                return false;

            if (pSourceIndex >= _groups.Count || pTargetIndex >= _groups.Count)
                return false;

            var sourceGroup = _groups[pSourceIndex];
            var targetGroup = _groups[pTargetIndex];
            targetGroup.AddMaterial(pMaterial);
            sourceGroup.RemoveMaterial(pMaterial);
            return true;
        }
        public void ChangeAtlasMaterialToIgnored(GroupAtl pGroup, MaterialAtl pMaterial)
        {
            pGroup.RemoveMaterial(pMaterial);
            GroupAtl ga = new GroupAtl(pMaterial.name, true, true);
            ga.AddMaterial(pMaterial);
            _groups.Add(ga);
        }
        public void ChangeAtlasMaterialFromIgnored(GroupAtl pSourceGroup, GroupAtl pTargetGroup = null)
        {
            MaterialAtl ma = pSourceGroup.GetMaterials().First();
            if (pTargetGroup != null)
                pTargetGroup.AddMaterial(ma);
            else
            {
                pTargetGroup = _groups.Where(x => x.isIgnored == false && x.hasTextureImages == true).FirstOrDefault();
                pTargetGroup.AddMaterial(ma);
            }
            _groups.Remove(pSourceGroup);
        }

        public void Generate(string pOutputName, string pOutputDirectory)
        {
            //copy the original into the modified 
            _objModified = _objOriginal.DeepClone();

            //solve only the groups we want to solve
            foreach (var g in _groups.Where(x => x.isIgnored == false && x.hasTextureImages == true))
            {
                //solve the group
                g.Solve();

                //go through each material in the group
                foreach (var m in g.GetMaterials())
                {
                    //now go through each group in the object
                    foreach (var og in _objModified.GetGroupsUsingMaterialName(m.name))
                    {
                        //update the material name to this one
                        og.materialName = g.name;

                        //go through the faces and vertices and update the UV coordinates
                        foreach (var f in og.GetFaces())
                        {
                            foreach (var v in f.GetVertices())
                            {
                                var uv = v.GetTextureUV();
                                uv.X = (uv.X + m.uvNormalizer.X);
                                uv.X = uv.X * m.uvScale.X * m.SizeInBinPercentage.X;
                                uv.X += m.OriginInBinPercentage.X;

                                uv.Y = (uv.Y + m.uvNormalizer.Y);
                                uv.Y = uv.Y * m.uvScale.Y * m.SizeInBinPercentage.Y;
                                uv.Y += m.OriginInBinPercentage.Y;
                            }
                        }
                    }
                }
            }

            //now write out obj file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pOutputDirectory + pOutputName + ".obj"))
            {
                //write the material name
                file.WriteLine("mtllib {0}.mtl", pOutputName);
                file.WriteLine("");

                //write out the modified obj file
                _objModified.WriteFile(file);
                file.Close();
            }

            //now write out obj file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pOutputDirectory + pOutputName + ".mtl"))
            {
                //now write out the materials where they're not ignored and have texture images
                foreach (var g in _groups.Where(x => x.isIgnored == false && x.hasTextureImages == true))
                {
                    file.WriteLine("newmtl {0}", g.name);
                    file.WriteLine("Ka 0.000000 0.000000 0.000000");
                    file.WriteLine("Kd 1.000000 1.000000 1.000000");
                    file.WriteLine("Ks 0.000000 0.000000 0.000000");
                    file.WriteLine("d 1.000000");
                    file.WriteLine("illum 2");
                    file.WriteLine("Ns 1.000000");
                    file.WriteLine("map_Kd {0}.{1}", g.name, "png");
                    //file.WriteLine("map_Bump {0}.{1}", g.name, "png");
                    file.WriteLine("");
                }

                //now write out the materials where they're ignored and have texture images
                foreach (var g in _groups.Where(x => x.isIgnored == true && x.hasTextureImages == true))
                {
                    Material m = _objOriginal.GetMaterial(g.name);
                    foreach (var l in m.GetRawMaterialData())
                    {
                        file.WriteLine(l);
                    }
                    file.WriteLine("");
                }

                //now write out the materials where they're ignored and don't have texture images
                foreach (var g in _groups.Where(x => x.isIgnored == true && x.hasTextureImages == false))
                {
                    Material m = _objOriginal.GetMaterial(g.name);
                    foreach (var l in m.GetRawMaterialData())
                    {
                        file.WriteLine(l);
                    }
                    file.WriteLine("");
                }
                
                file.Close();
            }

            //now copy the textures over
            foreach (var g in _groups)
            {
                //material has ignored textures
                if (g.isIgnored == true && g.hasTextureImages == true)
                {
                    string fm = g.GetFirstTextureFilename();
                    if (File.Exists(pOutputDirectory + Path.GetFileName(fm)))
                        File.Delete(pOutputDirectory + Path.GetFileName(fm));

                    File.Copy(fm, pOutputDirectory + Path.GetFileName(fm));
                }
                //material has atlas
                else if (g.isIgnored == false && g.hasTextureImages == true)
                {
                    Image img = g.RenderToImage();
                    img.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
                    img.Save(pOutputDirectory + g.name + ".png");
                }
            }
           
        }
    }
}
