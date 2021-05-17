using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomework
{
    public static class Cheat
    {
        public static string MakeString(char character, int count)
        {
            string newString = "";
            for(int i = 0; i< count; i++)
                newString += character;
            return newString;
        }
    }
}
