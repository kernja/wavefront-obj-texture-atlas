using ObjAtlas.Extensions;
using ObjAtlas.WaveFront.Mat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Containers
{
    [Serializable]
    public class MatFile
    {
        public string fileName { get; set; }
        public string folderDirectory { get; set; }

        private IList<Material> _materials;

        public MatFile(string pFile, string pDir)
        {
            fileName = pFile;
            folderDirectory = pDir;
            _materials = new List<Material>();
            this.LoadFromFile();
        }

        /*
        public IList<string> GetTextureNamesUsedInMaterials()
        {
            IList<string> textureNames = new List<string>();
            foreach (var m in materials) 
               foreach (var t in m.textureFileNames)
                {
                    if (!textureNames.Contains(t))
                        textureNames.Add(t);
                }

            return textureNames.ToList();
        }
        */
        public IList<Material> GetMaterials(IList<string> pNames = null)
        {
            if (pNames == null)
                return _materials.ToList();

            return _materials.Where(x => pNames.Contains(x.materialName)).ToList();
        }

        public IList<string> GetMaterialNamesContainingTexture(string pTextureName)
        {
            return _materials.Where(x => x.ContainsTexture(pTextureName)).Select(x => x.materialName).ToList();
        }
        private void LoadFromFile()
        {
            var lines = File.ReadAllLines(this.folderDirectory + this.fileName);
            var rawData = new List<string>();

            Material m = null;
            foreach (var line in lines)
            {

                //clean up the input 
                string l = line.Trim();
                l = l.RemoveMultipleSpaces();

                //split the input
                string[] sSplit = l.Split(' ');

                //see if we're adding a new material
                if (l.StartsWith("newmtl ", StringComparison.InvariantCultureIgnoreCase))
                {
                    //add the existing material to the list
                    if (m != null)
                    {
                        //go through the raw data
                        //and add it to the material
                        foreach (var rd in rawData)
                        {
                            m.AddRawMaterialData(rd);
                        }
                        //now add it to the array
                        _materials.Add(m);
                    }
                    //clear out the old raw data
                    rawData.Clear();
                    
                    //add the new data
                    rawData.Add(line);

                    //create the new one
                    m = new Material(sSplit[1]);
                } else if (l.StartsWith("map_kd", StringComparison.InvariantCultureIgnoreCase))
                {
                    //check to see if the material exists
                    if (m == null)
                        throw new InvalidOperationException();

                    //check if the file exists
                    string file = this.folderDirectory + sSplit[sSplit.Length - 1];
                    if (!File.Exists(file))
                        throw new FileNotFoundException();
                    
                    //add it to the list of textures
                    m.AddTexture(sSplit[sSplit.Length - 1]);

                    //add the current raw line
                    rawData.Add(line);

                } else
                {
                    //add the current raw line
                    if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                        rawData.Add(line);
                }
            }
            //we're done parsing, so add the material to the list
            if (m != null)
            {
                //go through the raw data
                //and add it to the material
                foreach (var rd in rawData)
                {
                    m.AddRawMaterialData(rd);
                }

                //now add it to the array
                _materials.Add(m);
            }
            rawData.Clear();
        }

    }
}
