using ObjAtlas.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Obj
{
    [Serializable]
    public class Face
    {
        private IList<FaceVertexData> _vertexData;

        public Face()
        {
            _vertexData = new List<FaceVertexData>();
            for (int i = 0; i < 3; i++)
            {
                _vertexData.Add(new FaceVertexData());
            }
        }

        public Face(string parseData)
        {
            _vertexData = new List<FaceVertexData>();

            //clean up the strong
            parseData = parseData.Trim();
            parseData = parseData.RemoveMultipleSpaces();

            //now create the new vertices
            string[] sString = parseData.Split(' ');
            foreach (string s in sString)
            {
                _vertexData.Add(new FaceVertexData(s));
            }
        }

        public List<FaceVertexData> GetVertices()
        {
            return _vertexData.ToList();
        }
        /*
        public IList<int> GetTextureUVIndices()
        {
            return this.vertexData.Select(x => x.vTextureIndex).Where(x => x > 0).Distinct().ToList();
        }

        public bool UsesTextures()
        {
            if (this.vertexData.Any(x => x.vTextureIndex == -1))
                return false;

            return true;
        }*/

        public string OutputToFile()
        {
            string myReturn = "f ";
            foreach (var v in _vertexData)
            {
                myReturn += v.OutputToFile();
            }

            return myReturn;
        }
    }
}
