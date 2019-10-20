using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10, i;
            int[] dane = new int[n];
            Console.WriteLine("Program wyświetla tablicę jednowymiarową " + n + " elementową");
            Console.WriteLine();

            for(i=0;i<n;i++)
            {
                dane[i] = n - 1 - i;
                Console.WriteLine("dane[" + i + "] = " + dane[i]);

            }
            Console.Read();

        }
    }
}
