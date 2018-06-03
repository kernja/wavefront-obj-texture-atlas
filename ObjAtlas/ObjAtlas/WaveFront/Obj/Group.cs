using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Obj
{
    [Serializable]
    public class Group
    {
        public string groupName { get; set; }
        public string materialName { get; set; }
        private IList<Face> _faces;

        public Group(string pName = "")
        {
            groupName = pName;
            materialName = "";
            _faces = new List<Face>();
        }

        public void AddFace(string parseData)
        {
            _faces.Add(new Face(parseData));
        }

        public List<Face> GetFaces()
        {
            return _faces.ToList();
        }

        public PointF GetUVMin()
        {
            float uMin = float.MaxValue;
            float vMin = float.MaxValue;

            foreach (var f in _faces)
            {
                foreach (var fv in f.GetVertices())
                {
                    var uv = fv.GetTextureUV();
                    if (uv != null)
                    {
                        if (uv.X < uMin)
                            uMin = uv.X;

                        if (uv.Y < vMin)
                            vMin = uv.Y;

                    }
                }
            }

            return new PointF(uMin, vMin);
        }

        public PointF GetUVMax()
        {
            float vMax = float.MinValue;
            float uMax = float.MinValue;

            foreach (var f in _faces)
            {
                foreach (var fv in f.GetVertices())
                {
                    var uv = fv.GetTextureUV();
                    if (uv != null)
                    {
                        if (uv.X > uMax)
                            uMax = uv.X;

                        if (uv.Y > vMax)
                            vMax = uv.Y;
                    }
                }
            }

            return new PointF(uMax, vMax);
        }

        public string OutputToFile()
        {
            string myReturn = string.Format("g {0}\nusemtl {1}\n", groupName, materialName);

            foreach (var f in _faces)
            {
                myReturn += f.OutputToFile() + "\n";
            }

            return myReturn;
        }
    }
}
