using System;

namespace ConsoleApplication
{
    class Program
    {
        int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a % b);
            }
        }
        
        static void Main(string[] args)
        {
            Program yo = new Program();
            
            int a = 0, b = 0, c = 0, d = 0;
            a = Int32.Parse(Console.ReadLine());
            b = Int32.Parse(Console.ReadLine());

            c = a / yo.gcd(a, b);
            d = b / yo.gcd(a, b);
            
            Console.WriteLine(c + "/" + d);
        }
    }
}
