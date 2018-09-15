using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = Int32.Parse(Console.ReadLine());
            //int b = Int32.Parse(Console.ReadLine());
            //int c = Int32.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] tmp = s.Split(' ');
            int a = int.Parse(tmp[0]);
            int b = int.Parse(tmp[1]);
            int c = int.Parse(tmp[2]);
            int p1, p2, p3;
            
            
            int k = 0, result = 0;
            k = (a + b + c) / 3;
            
            if ((a + b + c) % 3 != 0)
            {
                Console.WriteLine("IMPOSSIBLE");
            }
            else
            {
                p1 = a - k;
                p2 = b - k;
                p3 = c - k;
                result = (Math.Abs(p1) + Math.Abs(p2) + Math.Abs(p3)) / 2;
                Console.WriteLine(result);
            }
        }
    }
}
