using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10, i;

            int[] dane = new int[n];

            Console.WriteLine("Program wyświetla zawartość tablicy jednowymiarowej " + n + " elementowej");
            Console.WriteLine();

            for(i=0; i<n; i++)
            {
                dane[i] = i;
                Console.WriteLine("dane[" + i + "] = " + dane[i]);
            }

            Console.Read();

        }
    }
}
