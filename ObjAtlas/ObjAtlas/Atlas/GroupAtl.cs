using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.Atlas
{
    public class GroupAtl
    {
        public bool hasTextureImages { get; set; }
        public bool isIgnored { get; set; }
        public string name { get; set; }

        private IList<MaterialAtl> _childMaterials { get; set; }

        private bool _atlasSolved = false;
        private int _atlasWidth;
        private int _atlasHeight;
        private IList<MaterialAtl> _atlasMaterials;

        public GroupAtl(string pName, bool pTextureImages, bool pIgnored)
        {
            hasTextureImages = pTextureImages;
            isIgnored = pIgnored;
            name = pName;

            _childMaterials = new List<MaterialAtl>();
        }

        public void AddMaterial(MaterialAtl pMat)
        {
            _childMaterials.Add(pMat);
        }
        public IList<MaterialAtl> GetMaterials()
        {
            return _childMaterials.ToList();
        }
        public MaterialAtl GetMaterialByName(string pName)
        {
            return _childMaterials.Where(x => x.name == pName).FirstOrDefault();
        }
        public void RemoveMaterial(MaterialAtl pMat)
        {
            _childMaterials.Remove(pMat);
        }

        public void Solve()
        {

            //reset
            _atlasSolved = false;

            //process all of the customizations that we want (e.g., custom sizings)
            //and reset the variables used during atlasing
            foreach (var m in _childMaterials)
                m.PrepareToSolveAtlas();

            //sort all of the pictures by area, from biggest to smallest
            var cm = _childMaterials.ToList();
            cm = cm.OrderByDescending(x => x.GetTextureAreaInAtlas()).ToList();

            //figure out the minimum length of each side of the bin we need to put the pictures in
            int minWidth = cm.Max(x => x.GetTextureDimensionsInAtlas().X);
            int minHeight = cm.Max(x => x.GetTextureDimensionsInAtlas().Y);

            //get the total area of all images
            int totalArea = cm.Sum(x => x.GetTextureAreaInAtlas());
            int totalSqrt = (int)Math.Sqrt(totalArea);

            //initially set the width and height to the square root of the image area
            _atlasWidth = totalSqrt;
            _atlasHeight = totalSqrt;

            //make sure we have the right sizes needed to fit the images
            _atlasWidth = (_atlasWidth < minWidth ? minWidth : _atlasWidth);
            _atlasHeight = (_atlasHeight < minHeight ? minHeight : _atlasHeight);

            //we want to make sure that we have enough space for the two biggest items in our atlas
            if (cm.Count > 1)
            {
                int takeTwoWidth = cm.Take(2).Sum(x => x.GetTextureDimensionsInAtlas().X);
                int takeTwoHeight = cm.Take(2).Sum(x => x.GetTextureDimensionsInAtlas().Y);

                _atlasWidth = (_atlasWidth < takeTwoWidth ? takeTwoWidth : _atlasWidth);
                _atlasHeight = (_atlasHeight < takeTwoHeight ? takeTwoHeight : _atlasHeight);
            }

            //round up to the nearest power of two
            _atlasWidth = NearestPow2(_atlasWidth);
            _atlasHeight = NearestPow2(_atlasHeight);
            
            //square up the images
            //not necessary but useful for 3d games
            if (_atlasWidth > _atlasHeight)
                _atlasHeight = _atlasWidth;
            else
                _atlasWidth = _atlasHeight;

            //sort all of the pictures by height, from biggest to smallest
            cm = cm.OrderByDescending(x => x.GetTextureDimensionsInAtlas().Y).ToList();
            //itarte through all pictures until they're placed
            while (cm.Any(x=> x.IsPlacedInBin() == false))
            {
                //go through canvas, vertically than horizontally
                for (int tY = 0; tY < _atlasHeight - 1; tY++)
                {
                    for (int tX = 0; tX < _atlasWidth -1; tX++)
                    {
                        //use placeholders
                        int x = tX;
                        int y = tY;

                        //get the first image placed in this location
                        var firstPlaced = cm.FirstOrDefault(i => i.TextureOccupiesSpaceInAtlas(x, y));
                        //get the first image not placed
                        var firstAvailable = cm.FirstOrDefault(i => (i.IsPlacedInBin() == false) &&
                                                                    (x + i.GetTextureDimensionsInAtlas().X - 1 <= _atlasWidth) &&
                                                                    (y + i.GetTextureDimensionsInAtlas().Y - 1 <= _atlasHeight));

                         //we can  only place if there's no image placed at the location AND
                         //if there's a new image that can fit
                         if ((firstPlaced == null) && (firstAvailable != null))
                         {
                            firstAvailable.PlaceInBin(x, y);
                            //move the cursor over by the width of the image
                            tX = tX + firstAvailable.GetTextureDimensionsInAtlas().X - 1; 
                         } else if (firstPlaced != null)
                         {
                            tX = tX + (firstPlaced.GetTextureDimensionsInAtlas().X - 1);
                         }

                         //escape the loop if there's nothing left to place
                        if (cm.All(i => i.IsPlacedInBin() == true))
                            break;
                    }

                    //escape the loop if there's nothing left to place
                    if (cm.All(i => i.IsPlacedInBin() == true))
                       break;
                }
            }

            //finish off the atlas
            _atlasSolved = true;
            _atlasMaterials = cm;
        }

        public Image RenderToImage()
        {
            if (!_atlasSolved)
                return null;

            Image canvas = new Bitmap(_atlasWidth, _atlasHeight);
            using (Graphics g = Graphics.FromImage(canvas))
            { 
                foreach (var m in _atlasMaterials)
                {
                    m.RenderTextureToAtlas(g);
                }
            }

            return canvas;
        }
        /*
         * Public Function ToImage() As Image
        'if we're not solved, throw an error
        If (_solved = False) Then
            Throw New Exception()
        End If

        'render the images
        'create the canvas
        Dim canvas As Image = New Bitmap(_width, _height)
        'go through each image in the list
        For Each img As GRBSImage In _pictureList
            'create a brush with each image
            Using brush As TextureBrush = New TextureBrush(img.Picture, Drawing2D.WrapMode.Tile)
                'create a graphic context and paste the brush to it, at the location
                Using g As Graphics = Graphics.FromImage(canvas)
                    g.FillRectangle(brush, Convert.ToSingle(img.X), Convert.ToSingle(img.Y), Convert.ToSingle(img.Width), Convert.ToSingle(img.Height))
                End Using
            End Using
        Next

        'return the image
        Return canvas
    End Function

         * */

        private int NearestPow2(int n)
        {
            return (int)Math.Pow(2, Math.Ceiling(Math.Log(n) / Math.Log(2)));
        }

        public override string ToString()
        {
            return name;
        }
    }
}
