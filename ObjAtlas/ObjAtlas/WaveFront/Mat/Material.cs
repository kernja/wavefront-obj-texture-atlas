using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Mat
{
     [Serializable]
    public class Material
    {
        public string materialName { get; set; }
        private IList<string> _rawMaterialData;

        private int _usageCount;
        private IList<string> _textureFileNames { get; set; }

        public Material(string pName = "")
        {
            materialName = pName;

            _usageCount = 0;
            _rawMaterialData = new List<string>();
            _textureFileNames = new List<string>();
        }
        public void AddRawMaterialData(string pString)
        {
            _rawMaterialData.Add(pString);
        }
        public void SetUsageCount(int pCount)
        {
            _usageCount = pCount;
        }
        public int GetUsageCount()
        {
            return _usageCount;
        }
        public bool MaterialUsed()
        {
            return (_usageCount != 0);
        }
        public bool HasTextures()
        {
            return (_textureFileNames.Count > 0);
        }

        public void AddTexture(string pName)
        {
            if (!_textureFileNames.Contains(pName))
                _textureFileNames.Add(pName);
        }
        public bool ContainsTexture(string pName)
        {
            return _textureFileNames.Contains(pName);
        }
        public string GetFirstTexture()
        {
            return _textureFileNames.First();
        }
    }
}
