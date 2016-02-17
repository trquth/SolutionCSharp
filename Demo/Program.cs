using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //A obj = new A();
            //B obj = new B();
            //C obj = new C();
            D obj = new DDerive();
            obj.Test();
            //obj.ShowText();
            Console.ReadLine();

        }
    }
}
