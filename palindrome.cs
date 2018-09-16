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
            int i = 1;
            s = s.ToLower();
            s = s.Replace(" ", "");

            foreach (char symbol in s)
            {
                if (symbol == s[s.Length - i])
                {
                    i += 1;
                    if (i == s.Length)
                    {
                        Console.WriteLine("Palindrome");
                    }
                }
                else
                {
                    Console.WriteLine("Not a palindrome");
                    break;
                }
            }
        }
    }
}
