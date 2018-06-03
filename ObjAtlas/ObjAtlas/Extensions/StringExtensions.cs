using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjAtlas.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveMultipleSpaces(this string str)
        {
            str = Regex.Replace(str, @"\s+", " ");
            return str;
        }
        public static string RemoveSpaces(this string str)
        {
            str = str.Replace(" ", "");
            return str;
        }
        
        //https://stackoverflow.com/questions/1120198/most-efficient-way-to-remove-special-characters-from-string
        public static string RemoveSpecialCharacters(this string str) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str) {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
