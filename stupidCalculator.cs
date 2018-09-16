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
            Console.WriteLine("Пожалуйста, введите два числа и операцию между ними:");
            
            string expression = Console.ReadLine();
            string[] strNums = {};
            char operation = ' ';
            int result = 0;
            
            foreach (char el in expression)
            {
                if (el == '+' | el == '-' | el == '*' | el == '/')
                {
                    strNums = expression.Split(el);
                    operation = el;
                }    
            }

            int num1 = Int32.Parse(strNums[0]);
            int num2 = Int32.Parse(strNums[1]);
            
            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
            }
            Console.WriteLine(expression + "=" + result);
        }
    }
}
