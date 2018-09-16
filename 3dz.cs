using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] tmp = s.Split(' ');
            int n = int.Parse(tmp[0]);
            int a = int.Parse(tmp[1]);
            int b = int.Parse(tmp[2]);
            int width = int.Parse(tmp[3]);
            int height = int.Parse(tmp[4]);

            int d = 0, k = 0, num_w = 0, num_h = 0;

            int w = a + 2*d;
            int h = b + 2*d;

            num_w = width / w;
            num_h = height / h;

            for (int i = 0; i < width+height; i++)
            {
                if (num_w * num_h >= n)
                {
                    d += 1;
                    w = a + 2 * d;
                    h = b + 2 * d;
                    num_w = width / w;
                    num_h = height / h;
                    
                }
                else
                {
                    if (d != 0)
                    {
                        d -= 1;
                    }
                    else
                    {
                        d = 0;
                    }
                    break;
                }
            }
            
            num_w = width / h;
            num_h = height / w;
            
            for (int i = 0; i < width+height; i++)
            {
                if (num_w * num_h >= n)
                {
                    k += 1;
                    w = a + 2 * k;
                    h = b + 2 * k;
                    num_w = width / h;
                    num_h = height / w;
                    
                }
                else
                {
                    if (k != 0)
                    {
                        k -= 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    break;
                }
            }
            
            if (d > k)
            {
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine(k);
            }

        }
    }
}
