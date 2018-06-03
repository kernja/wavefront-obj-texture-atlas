using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.Extensions
{
   public static class CloneExtensions
    {
        // Deep clone
        //https://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-of-an-object-in-net-c-specifically
        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}
