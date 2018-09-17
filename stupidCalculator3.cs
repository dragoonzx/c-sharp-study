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
            Console.WriteLine("Пожалуйста, введите три числа и две операции между ними через Enter:");
            
            int num1 = Int32.Parse(Console.ReadLine());
            string op1 = Console.ReadLine();
            int num2 = Int32.Parse(Console.ReadLine());
            string op2 = Console.ReadLine();
            int num3 = Int32.Parse(Console.ReadLine());
            int result = 0;

            if (op1 == "/" & num2 == 0 | op2== "/" & num3 == 0)
            {
                Console.WriteLine("На ноль делить нельзя!");
            }
            
            if (op1 == "*")
            {
                result = num1 * num2;
                if (op2 == "*")
                    result *= num3;
                if (op2 == "/")
                    result /= num3;
                if (op2 == "+")
                    result += num3;
                if (op2 == "-")
                    result -= num3;
            }

            if (op1 == "/")
            {
                result = num1 / num2;
                if (op2 == "*")
                    result *= num3;
                if (op2 == "/")
                    result /= num3;
                if (op2 == "+")
                    result += num3;
                if (op2 == "-")
                    result -= num3;
            }

            if (op1 == "+")
            {
                if (op2 == "*")
                {
                    result = num2 * num3;
                    result += num1;
                }

                if (op2 == "/")
                {
                    result = num2 / num3;
                    result += num1;
                }
                if (op2 == "+")
                    result = num1 + num2 + num3;
                if (op2 == "-")
                    result = num1 + num2 - num3;
            }

            if (op1 == "-")
            {
                if (op2 == "*")
                {
                    result = num2 * num3;
                    result = num1 - result;
                }

                if (op2 == "/")
                {
                    result = num2 / num3;
                    result = num1 - result;
                }

                if (op2 == "+")
                    result = num1 - num2 + num3;
                if (op2 == "-")
                    result = num1 - num2 - num3;
            }

            Console.WriteLine(result);
        }
    }
}
