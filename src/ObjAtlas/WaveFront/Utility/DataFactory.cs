using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjAtlas.WaveFront.Utility
{
    [Serializable]
    public class DataFactory<T>
    {
        private int _indexOffset;
        private List<T> _objects;

        public DataFactory(int indexOffset = 1)
        {
            _objects = new List<T>();
            _indexOffset = indexOffset;
        }

        public int Add(T value, bool useExisting = false)
        {
            if (useExisting == false)
                _objects.Add(value);

            if (useExisting == true && !_objects.Contains(value))
                _objects.Add(value);

            return this._objects.LastIndexOf(value) + _indexOffset;
        }

        public T ObjectAtIndex(int index)
        {
            return this._objects[index - _indexOffset];
        }

        public void Clear()
        {
            this._objects.Clear();
        }

        public int GetIndexOf(T value)
        {
            return this.Add(value, true);
        }

        public IList<T> GetObjects()
        {
            return this._objects.ToList();
        }

        public void OutputToFile(StreamWriter pWriter, string pUsingFormatString)
        {
            foreach (var obj in _objects)
            {
                pWriter.WriteLine(string.Format(pUsingFormatString, obj.ToString()));
            }
            pWriter.WriteLine("# Count: " + _objects.Count.ToString());
            pWriter.WriteLine("");

        }
    }
}
