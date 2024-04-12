using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(495 / 100);
            Console.WriteLine(495.01 / 100);
            Console.WriteLine((int)495.01 / 100);
            Console.WriteLine(495 % 100);
            Console.WriteLine(495.01 % 100);
            Console.WriteLine();

            Console.WriteLine($"{(int)495.01 / 100}+{495.01 % 100}");


            Console.ReadKey();
        }
    }
}
