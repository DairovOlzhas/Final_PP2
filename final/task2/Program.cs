using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {

        static bool Prime(int a)
        {
            for(int i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0)
                    return false;
            return true;
        }

        static bool Check(string[] a)
        {
            foreach(string s in a)
            {
                string[] b = s.Split(' ');
                foreach(string ss in b)
                    if (ss != "")
                        if (Prime(int.Parse(ss)))
                            return true;

            }
            return false;
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\d.heyoung.b\Desktop\Новая папка";
            DirectoryInfo d = new DirectoryInfo(path);

            foreach(FileInfo f in d.GetFiles())
            {
                string[] a = File.ReadAllLines(f.FullName);
                if (Check(a))
                    Console.WriteLine(f.Name);
            }

            Console.ReadKey();
        }
    }
}
