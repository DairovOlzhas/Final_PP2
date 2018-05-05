using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {

        static bool Pal(string a)
        {
            for(int i = 0; i < a.Length/2; i++)
            {
                if (a[i] != a[a.Length - 1 - i])
                    return false;
            }

            return true;
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            
            int k = 0;
            string[] b = a.Split(' ');

            Console.WriteLine(b.Count());

            foreach(string s in b)
            {
                if (Pal(s))
                    k++;
            }

            Console.WriteLine(k);

            Console.ReadKey();

        }
    }
}
