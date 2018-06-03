using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjAtlas.Atlas
{
    public class MaterialAtl { 

        public string name { get; set; }
        public string textureFilename { get; set; }
        public Image textureImage { get; set; }

        //used for storing the original texture size
        public Point textureSize;
        //used for storing the size if the texture is repeated on a surface.
        public Point textureRepeatedSize;
        //store how many times a texture is repeated on a surface
        public PointF timesRepeated;

        //store the original minimum coordinates that a texture is visible (top left corner)
        public PointF uvMin;
        //store the original maxium coordinates that at exture is visible (bottom right corner)
        public PointF uvMax;
        //store the offset needed, so that the minimum - top left corner - of the texture
        //has an origin that falls between 0 and 1
        public PointF uvNormalizer; 

        //if a texture is repeated, e.g., 4x2 times at 256x256px,
        //it would take a 1024x512 chunk of the atlas.
        //this value is to scale the repeated size a bit.
        //if this value is .5 x .5, the desired out put would be
        //(4 x 256 x .5 = 512)
        //(2 x 256 x .5 = 256)
        //this gives us a considerable savings in memory and space used in the atlas.
        public PointF targetTextureScale;

        //store these values once they're normalized
        public PointF uvMinNormalized;
        public PointF uvMaxNormalized;
        
        //if a texture is repeated, e.g., 0/0 to 4/2,
        //store the scale value required to get it down to a 0-1 range.
        //in this example, if we repeat a texture 4 x 2 times,
        //the X value would be .25 (4 x .25 = 1)
        //while the Y value would be .5 (2 x .5 = 1)
        public PointF uvScale; //uScale/vScale

        //now, do actually do our magic, we need to adjust the UV coordinates.
        //multi step process:
        //1. normalize the coordinates
        //2. atlas the textures into a texture map
        //3. once a texture is a part of the texture map, store the origin (top-left point)
        //        and the percentage it takes up of the atlas, in percentages
        //            EXAMPLE: if an atlas is 1024x1024 in size, and we're inspecting a texture that's 512x256 in size
        //                     and that 512x256 texture is positioned at 64x128 in the atlas
        //                         Origin X/U coordinate: 64 / 1024 = .0625 (texturePercentageOffsetU)
        //                         Origin Y/V coordinate: 128 / 1024 = .1250 (texturePercentageOffsetV)
        //                         Atlas size percentage (Width): 512/1024 = .5 (texturePercentageScaleU)
        //                         Atlas size percentage (height): 256/1024 = .25 (texturePercentageScaleV)
        //4. take the UV coordinates from the mesh, add the factor to normalize them, and then and multiply them:
        //   newU = (uOriginal + uNormalizer) * uScale * texturePercentageScaleU;
        //   newV = (vOriginal + vNormalizer) * vScale * texturePercentageScaleV;
        //5. then offset them
        //   newU = newU + texturePercentageOffsetU;
        //   newV = newV + texturePercentageOffsetV;
        //6. update all UV coordinates in the meshes.

        private Point _originInBin;
        private Point _sizeInBin;
        private PointF _originInBinPercentage;
        private PointF _sizeInBinPercentage;
        private bool _placedInBin;

        public MaterialAtl(string materialName)
        {
            name = materialName;
            textureFilename = null;
            textureImage = null;
        }

        public MaterialAtl(string materialName, string fileName, string folderName)
        {
            name = materialName;
            textureFilename = folderName + fileName;
            textureImage = Image.FromFile(textureFilename);

            uvMin = new PointF(0, 0);
            uvMax = new PointF(0, 0);
            uvNormalizer = new PointF(0, 0);
            uvScale = new PointF(0, 0);

            timesRepeated = new Point(0, 0);
            //targetTextureScale = new PointF(1, 1);
            targetTextureScale = new PointF(100f, 100f);
            textureRepeatedSize = new Point(0, 0);
            textureSize = new Point(0, 0);
        }

        public void ProcessUVData(PointF pMin, PointF pMax)
        {
             this.uvMin = pMin;
             this.uvMax = pMax;

             //U in UV
             if (pMin.X >= 1)
             {
                uvNormalizer.X = (float)Math.Floor(pMin.X) * -1;
             } else if (pMin.X < 0)
             {
                uvNormalizer.X = (float)Math.Ceiling(Math.Abs(pMin.X));
             }

             //V in UV
             if (pMin.Y >= 1)
             {
                uvNormalizer.Y = (float)Math.Floor(pMin.Y) * -1;
             } else if (pMin.Y < 0)
             {
                uvNormalizer.Y = (float)Math.Ceiling(Math.Abs(pMin.Y));
             }

             uvMinNormalized = new PointF(uvMin.X + uvNormalizer.X, uvMin.Y + uvNormalizer.Y);
             uvMaxNormalized = new PointF(uvMax.X + uvNormalizer.X, uvMax.Y + uvNormalizer.Y);
             //get how many times the texture repeats
             this.timesRepeated = new PointF((float)(Math.Ceiling(uvMax.X + uvNormalizer.X) - Math.Floor(uvMin.X+ uvNormalizer.X)),
                (float)(Math.Ceiling(uvMax.Y + uvNormalizer.Y) - Math.Floor(uvMin.Y+ uvNormalizer.Y)));

            if (timesRepeated.X < 1)
                timesRepeated.X = 1;
            if (timesRepeated.Y < 1)
                timesRepeated.Y = 1;

            this.textureSize = new Point(textureImage.Width, textureImage.Height);
            this.textureRepeatedSize = new Point((int)((float)textureImage.Width * timesRepeated.X), (int)((float)textureImage.Height * timesRepeated.Y));
            this.uvScale = new PointF(1f / timesRepeated.X, 1f / timesRepeated.Y);
        }

        public void PrepareToSolveAtlas()
        {W
            _originInBin = new Point(0, 0);
            _sizeInBin = new Point((int)((float)textureRepeatedSize.X * (targetTextureScale.X * .01)), (int)((float)textureRepeatedSize.Y * (targetTextureScale.Y * .01)));
            _placedInBin = false;
        }
        public bool IsPlacedInBin()
        {
            return _placedInBin;
        }
        public void PlaceInBin(int pX, int pY)
        {
            _placedInBin = true;
            _originInBin = new Point(pX, pY);
        }
        public Point GetTextureDimensionsInAtlas()
        {
            return _sizeInBin;
        }
        public int GetTextureAreaInAtlas()
        {
            return (_sizeInBin.X * _sizeInBin.Y);
        }
        public bool TextureOccupiesSpaceInAtlas(int pX, int pY)
        {
            if (!_placedInBin)
                return false;

            int x1, y1;
            x1 = _originInBin.X;
            y1 = _originInBin.Y;

            int x2, y2;
            x2 = x1 + _sizeInBin.X - 1;
            y2 = y1 + _sizeInBin.Y - 1;

            if ((pX >= x1 && pY >= y1) && (pX <= x2 && pY <= y2))
                return true;

            return false;
        }

        public void RenderTextureToAtlas(Graphics g)
        {
            using (TextureBrush txb = new TextureBrush(this.textureImage, WrapMode.Tile))
            {
                txb.TranslateTransform(_originInBin.X, _originInBin.Y);
                txb.ScaleTransform(targetTextureScale.X * .01f, targetTextureScale.Y * .01f);
                g.FillRectangle(txb, _originInBin.X, _originInBin.Y, _sizeInBin.X, _sizeInBin.Y);
            }
        }

        public void OutputToListBox(ListBox lstBox)
        {
            IList<string> output = new List<string>();
            output.Add(string.Format("Ori uMin: {0}", (uvMin.X).ToString()));
            output.Add(string.Format("Ori vMin: {0}", (uvMin.Y).ToString()));
            output.Add(string.Format("Ori uMax: {0}", (uvMin.X).ToString()));
            output.Add(string.Format("Ori vMax: {0}", (uvMin.Y).ToString()));
            output.Add(string.Format("New uMin: {0}", (uvMinNormalized.X).ToString()));
            output.Add(string.Format("New vMin: {0}", (uvMinNormalized.Y).ToString()));
            output.Add(string.Format("New uMax: {0}", (uvMaxNormalized.X).ToString()));
            output.Add(string.Format("New vMax: {0}", (uvMaxNormalized.Y).ToString()));
            output.Add(string.Format("Size: {0}, {1} ", textureSize.X.ToString(), textureSize.Y.ToString()));
            output.Add(string.Format("Times repeated: {0}, {1} ", timesRepeated.X.ToString(), timesRepeated.Y.ToString()));
            output.Add(string.Format("Total req. size: {0}, {1} ", textureRepeatedSize.X.ToString(), textureRepeatedSize.Y.ToString()));
            output.Add(string.Format("UV Scale: {0}, {1} ", uvScale.X.ToString(), uvScale.Y.ToString()));

            lstBox.Items.Clear();
            foreach (var s in output)
            {
                lstBox.Items.Add(s);
                Console.WriteLine(s);
            }

        }

        public void OutputPreviewImage(PictureBox picBox)
        {
            Bitmap b = new Bitmap(textureSize.X, textureSize.Y);
            using (TextureBrush txb = new TextureBrush(this.textureImage))
            {
                txb.ScaleTransform(uvScale.X, uvScale.Y);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.FillRectangle(txb, 0, 0, textureSize.X, textureSize.Y);
                }
            }

            picBox.Image = b;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
