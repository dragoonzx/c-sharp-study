using System;
using System.Diagnostics;
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
            
            
            
            int k = 0, result = 0;
            k = (a + b + c) / 3;
            
            if ((a + b + c) % 3 != 0)
            {
                Console.WriteLine("IMPOSSIBLE");
            }
            else if (a > k)
            {
                result += a - k;
                Console.WriteLine(result);
            }

            else if (b > k)
             {
                 result += b - k;
                 Console.WriteLine(result);
             }
            else if (c > k)
             {
                  result += c - k;
                  Console.WriteLine(result);
             }      
                
            
            }
        }
    }
