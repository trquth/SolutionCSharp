using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abcd";
            string[] splipt = new string[2];
            for (int i = 0; i < 2; i++)
            {
                splipt[i] = text.Substring(i * 2, i * 2 + 2 > text.Length ? 1 : 2);
            }
            string textNew = splipt[1] + splipt[0];
            Console.ReadLine();
        }
    }
}
