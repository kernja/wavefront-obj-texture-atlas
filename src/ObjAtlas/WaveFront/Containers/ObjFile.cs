﻿using ObjAtlas.Extensions;
using ObjAtlas.WaveFront.Mat;
using ObjAtlas.WaveFront.Obj;
using ObjAtlas.WaveFront.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Containers
{
    [Serializable]
    public class ObjFile
    {
        public string folderDirectory { get; set; }
        public string fileName { get; set; }

        private IList<Group> _groups;
        private IList<MatFile> _materialFiles;

        private DataFactory<Vertex> _factoryVertices = new DataFactory<Vertex>();
        private DataFactory<Vertex> _factoryParameterVertices = new DataFactory<Vertex>();
        private DataFactory<Vertex> _factoryNormals = new DataFactory<Vertex>();
        private DataFactory<UV> _factoryTexCoords = new DataFactory<UV>();

        public ObjFile()
        {
            _groups = new List<Group>();
            _materialFiles = new List<MatFile>();
        }

        public void LoadFile(string path)
        {
            //set the environment variables;
            this.fileName = Path.GetFileName(path);
            this.folderDirectory = Path.GetDirectoryName(path) + "\\";

            //declare a generic group
            Group g = null;

            //iterate through the files
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                //print the line for debugging purposes
                Console.WriteLine(line);

                //clean up the input
                string l = line.Trim();
                l = l.RemoveMultipleSpaces();

                //split the string into a maximum of two chunks 
                string[] sSplit = l.Split(new char[] { ' ' }, 2);


                //get the material name
                if (l.StartsWith("mtllib", StringComparison.InvariantCultureIgnoreCase))
                {
                    _materialFiles.Add(new MatFile(sSplit[1], this.folderDirectory));
                }
                //or vertex
                else if (l.StartsWith("v ", StringComparison.InvariantCultureIgnoreCase))
                {
                    _factoryVertices.Add(new Vertex(sSplit[1]));               
                }
                //or vertex normal 
                else if (l.StartsWith("vn ", StringComparison.InvariantCultureIgnoreCase))
                {
                    _factoryNormals.Add(new Vertex(sSplit[1]));
                }
                //or vertex textures     
                else if (l.StartsWith("vt ", StringComparison.InvariantCultureIgnoreCase))
                {
                    _factoryTexCoords.Add(new UV(sSplit[1]));
                }
                //or vertex parameters?     
                else if (l.StartsWith("vp ", StringComparison.InvariantCultureIgnoreCase))
                {
                    _factoryParameterVertices.Add(new Vertex(sSplit[1]));
                }
                //or create a group
                else if (l.StartsWith("g ", StringComparison.InvariantCultureIgnoreCase))
                {
                    //we have a group defined already, add it to the list of groups 
                    if (g != null)
                        _groups.Add(g);

                    g = new Group(sSplit[1]);
                }
                //or set a material a group
                else if (l.StartsWith("usemtl ", StringComparison.InvariantCultureIgnoreCase))
                {
                    //if we don't have a group defined, create a group
                    if (g == null)
                    {
                        g = new Group();
                    }
                    //a group can only have one material
                    else if (g != null && !String.IsNullOrEmpty(g.materialName) && !g.materialName.Equals(sSplit[1]))
                    {
                        //add the existing group
                        _groups.Add(g);

                        //create a new group
                        string gName = g.groupName;
                        g = new Group(gName);
                    }

                    //set the material name to the group 
                    g.materialName = sSplit[1];
                }
                else if (l.StartsWith("f ", StringComparison.InvariantCultureIgnoreCase))
                {
                    //if we don't have a group defined, create a new group 
                    if (g == null)
                        g = new Group();

                    //add the face to the group
                    g.AddFace(sSplit[1]);
                }
            }

            //finally add the last group to the mix
            if (g != null)
                _groups.Add(g);

            //optimize al of the groups      
            for (int i = 0; i < _groups.Count; i++)
            {
                //do the merge
                for (int j = 0; j < _groups.Count; j++)
                {
                    //we only want to do the merge of higher indexed items into lower ones
                    if (i < j && _groups[i].GetFaceCount() > 0)
                    {
                        //ensure that the material and group names match, and that the face count is greater than zero
                        if (_groups[j].GetFaceCount() > 0 && _groups[i].groupName.Equals(_groups[j].groupName) && _groups[i].materialName.Equals(_groups[j].materialName))
                        {
                            _groups[i].AddFaces(_groups[j].GetFaces());
                            _groups[j].ClearFaces();
                        }
                    }
                }
            }
            
            //now do the perge
            for (int j = _groups.Count - 1; j >= 0; j--)
            {
                if (_groups[j].GetFaceCount() == 0)
                    _groups.RemoveAt(j);
            }


            //we've gone through the entire file to clean things up
            //mark how many times a material is in use
            foreach (var m in this.GetMaterials(null, false))
            {
                m.SetUsageCount(_groups.Where(x => x.materialName == m.materialName).Count());
            }

            //now go through and replace the indexed values with values from our factories
            foreach (var gg in _groups)
            {
                foreach (var ff in gg.GetFaces())
                {
                    foreach (var fv in ff.GetVertices())
                    {
                        fv.LoadDataFromFactories(_factoryVertices,
                            _factoryTexCoords,
                            _factoryNormals);
                    }
                }
            }
            //IList<string> testString = new List<string> { "green5", "green11" };
            //this.GetMaterials(testString);
            //this.GetGroupsUsingMaterialNames(testString);
        }

        public void WriteFile(StreamWriter pWriter)
        {
            _factoryVertices.Clear();
            _factoryNormals.Clear();
            _factoryTexCoords.Clear();
            _factoryVertices.Clear();

            //now go through and replace the values from factories with what we have stored
            foreach (var gg in _groups)
            {
                foreach (var ff in gg.GetFaces())
                {
                    foreach (var fv in ff.GetVertices())
                    {
                        fv.LoadDataIntoFactories(_factoryVertices,
                            _factoryTexCoords,
                            _factoryNormals);
                    }
                }
            }

            //now write out the data in each of the factories
            _factoryVertices.OutputToFile(pWriter, "v {0}");
            _factoryTexCoords.OutputToFile(pWriter, "vt {0}");
            _factoryNormals.OutputToFile(pWriter, "vn {0}");
            _factoryParameterVertices.OutputToFile(pWriter, "vp {0}");

            //now write out the data for each group
            foreach(var g in _groups)
            {
                pWriter.WriteLine(g.OutputToFile());
            }
        }

        public Material GetMaterial(string materialName)
        {
            var mf = _materialFiles.Where(x => x.ContainsMaterial(materialName)).FirstOrDefault();
            if (mf != null)
                return mf.GetMaterial(materialName);

            return null;
        }


        public IList<Material> GetMaterials(IList<string> materialNames = null, bool excludeUnused = true)
        {
            List<Material> lm = new List<Material>();
            foreach (var mf in _materialFiles)
                foreach (var m in mf.GetMaterials(materialNames))
                    if (!excludeUnused || m.MaterialUsed())
                        lm.Add(m);

            return lm;
        }

        public IList<Group> GetGroupsUsingMaterialName(string pMaterialName)
        {
            List<Group> lm = _groups.Where(x => x.materialName == pMaterialName).ToList();

            return lm;
        }

        public IList<Group> GetGroupsUsingMaterialNames(IList<string> materialNames)
        {
            List<Group> lm = _groups.Where(x => materialNames.Contains(x.materialName)).ToList();

            return lm;
        }

        public PointF GetUVMin(string materialName)
        {
            float uMin = float.MaxValue;
            float vMin = float.MaxValue;

            PointF p;
            foreach (var g in _groups.Where(X => X.materialName == materialName).ToList())
            {
                p = g.GetUVMin();
                if (uMin > p.X)
                    uMin = p.X;

                if (vMin > p.Y)
                    vMin = p.Y;
            }

            return new PointF(uMin, vMin);
        }
         public PointF GetUVMax(string materialName)
        {
            float uMax = float.MinValue;
            float vMax = float.MinValue;

            PointF p;
            foreach (var g in _groups.Where(X => X.materialName == materialName).ToList())
            {
                p = g.GetUVMax();
                if (uMax < p.X)
                    uMax = p.X;

                if (vMax < p.Y)
                    vMax = p.Y;
            }

            return new PointF(uMax, vMax);
        }

    }
}
