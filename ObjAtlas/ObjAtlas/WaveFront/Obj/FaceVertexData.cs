using ObjAtlas.Extensions;
using ObjAtlas.WaveFront.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Obj
{
    [Serializable]
    public class FaceVertexData
    {
        private int _vIndex = 0;
        private int? _vTextureIndex = null;
        private int? _vNormalIndex = null;

        private Vertex _vertex { get; set; }
        private UV _texture { get; set; }
        private Vertex _normal { get; set; }

        public FaceVertexData()
        {
            _vertex = new Vertex(0, 0, 0);
            _texture = null;
            _normal = null;
        }
        public FaceVertexData(string parseData)
        {
            //clean up the string
            parseData = parseData.Trim();
            parseData = parseData.RemoveSpaces();

            //get the data
            if (parseData.Contains("/"))
            {
                string[] sSplit = parseData.Split('/');
                if (sSplit.Length == 2)
                {
                    _vIndex = int.Parse(sSplit[0]);
                    _vTextureIndex = (!string.IsNullOrEmpty(sSplit[1]) ? int.Parse(sSplit[1]) : (int?)null);
                }
                else if (sSplit.Length == 3)
                {
                    _vIndex = int.Parse(sSplit[0]);
                    _vTextureIndex = (!string.IsNullOrEmpty(sSplit[1]) ? int.Parse(sSplit[1]) : (int?)null);
                    _vNormalIndex = (!string.IsNullOrEmpty(sSplit[2]) ? int.Parse(sSplit[2]) : (int?)null);
                }
                else
                {
                    throw new InvalidOperationException("Invalid file data");
                }
            }
            else
            {
                _vIndex = int.Parse(parseData);
            }
        }

        public void LoadDataFromFactories(DataFactory<Vertex> pVertexFactory, DataFactory<UV> pTextureFactory, DataFactory<Vertex> pNormalFactory)
        {
            _vertex = pVertexFactory.ObjectAtIndex(_vIndex);

            if (_vTextureIndex.HasValue)
                _texture = pTextureFactory.ObjectAtIndex(_vTextureIndex.Value);

            if (_vNormalIndex.HasValue)
                _normal = pNormalFactory.ObjectAtIndex(_vNormalIndex.Value);
        }

        public Vertex GetVertex()
        {
            return _vertex;
        }

        public UV GetTextureUV()
        {
            return _texture;
        }

        public Vertex GetNormals()
        {
            return _normal;
        }

        public void SetVertex(float pX, float pY, float pZ, float? pW = null)
        {
            _vertex = new Vertex(pX, pY, pZ, pW);
        }
        public void SetNormal(float pX, float pY, float pZ, float? pW = null)
        {
            _normal = new Vertex(pX, pY, pZ, pW);
        }
        public void SetTextureUV(float pU, float pV, float? pW = null)
        {
            _texture = new UV(pU, pV, pW);
        }

        public override string ToString()
        {
            return "FaceVertexData";
            /*
            if (_vTextureIndex == -1 && _vNormalIndex == -1)
            {
                return string.Format("{0}", _vIndex.ToString());
            } else if (_vTextureIndex != -1 && _vNormalIndex == -1)
            {
                return string.Format("{0}/{1}", _vIndex.ToString(), _vTextureIndex.ToString());
            } else if (_vTextureIndex == -1 && _vNormalIndex != -1)
            {
                    return string.Format("{0}//{1}", _vIndex.ToString(), _vNormalIndex.ToString());
            } else
            {
                    return string.Format("{0}/{1}/{2}", _vIndex.ToString(),  _vTextureIndex.ToString(), _vNormalIndex.ToString());
       
            }*/
        }
    }
}