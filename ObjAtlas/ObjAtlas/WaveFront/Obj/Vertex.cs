using ObjAtlas.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Obj
{
    [Serializable]
    public class Vertex
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float? W { get; set; }

        public Vertex(float pX, float pY, float pZ)
        {
            this.X = pX;
            this.Y = pY;
            this.Z = pZ;
            this.W = null;
        }
        public Vertex(float pX, float pY, float pZ, float? pW)
        {
            this.X = pX;
            this.Y = pY;
            this.Z = pZ;
            this.W = pW;
        }
        public Vertex(string parseData)
        {
            //set the default values
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.W = null;

            //clean up the string
            parseData = parseData.Trim();
            parseData = parseData.RemoveMultipleSpaces();

            //get the data
            string[] sSplit = parseData.Split(' ');
            if (sSplit.Length == 3)
            {
                this.X = float.Parse(sSplit[0]);
                this.Y = float.Parse(sSplit[1]);
                this.Z = float.Parse(sSplit[2]);
            } else if (sSplit.Length == 4)
            {
                this.X = float.Parse(sSplit[0]);
                this.Y =float.Parse(sSplit[1]);
                this.Z = float.Parse(sSplit[2]);
                this.W = float.Parse(sSplit[3]);
            } else
            {
                throw new InvalidOperationException("Invalid file data");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != (typeof(Vertex)))
                return false;

            var co = (Vertex)obj;

            if (co.X != this.X)
                return false;

            if (co.Y != this.Y)
                return false;

            if (co.Z != this.Z)
                return false;

            if (co.W != this.W)
                return false;

            return true;


        }

        public override int GetHashCode()
        {
            return string.Format("{0}_{1}_{2}_{3}", this.X, this.Y, this.Z, this.W).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ", this.X, this.Y, this.Z);
        }
    }
}
