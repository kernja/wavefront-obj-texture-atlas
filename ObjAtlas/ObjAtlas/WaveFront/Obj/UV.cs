using ObjAtlas.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Obj
{
    [Serializable]
    public class UV
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float? W { get; set; }

        public UV(float pU, float pV)
        {
            this.X = pU;
            this.Y = pV;
            this.W = null;
        }
        public UV(float pU, float pV, float? pW)
        {
            this.X = pU;
            this.Y = pV;
            this.W = pW;
        }
        
        public UV(string parseData)
        {
            //set the default values
            this.X = 0;
            this.Y = 0;
            this.W = null;

            //clean up the string
            parseData = parseData.Trim();
            parseData = parseData.RemoveMultipleSpaces();

            //get the data
            string[] sSplit = parseData.Split(' ');
            if (sSplit.Length == 2)
            {
                this.X = float.Parse(sSplit[0]);
                this.Y =float.Parse(sSplit[1]);
            } else if (sSplit.Length == 3)
            {
                this.X = float.Parse(sSplit[0]);
                this.Y = float.Parse(sSplit[1]);
                this.W = float.Parse(sSplit[2]);
            } else
            {
                throw new InvalidOperationException("Invalid file data");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != (typeof(UV)))
                return false;

            var co = (UV)obj;

            if (co.X != this.X)
                return false;

            if (co.Y != this.Y)
                return false;

            if (co.W != this.W)
                return false;

            return true;

        }

        public override int GetHashCode()
        {
            return string.Format("{0}_{1}_{2}", this.X, this.Y, this.W).GetHashCode();
        }
    }
}
