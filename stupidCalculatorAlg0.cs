using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение:");
            string expression = Console.ReadLine();
            
            
            Dictionary<char, int> priority = new Dictionary<char, int>(2)
            {
                ['*'] = 3,
                ['/'] = 3,
                ['+'] = 2,
                ['-'] = 2,
                ['('] = 1
            };

            Stack<char> opStack = new Stack<char>();
            List<char> postfixList = new List<char>();

            char[] tokenList = expression.ToCharArray();
            char[] nums = new char[10] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            
            // Переводим в постфиксную форму
            foreach (char token in tokenList)
            {
                if (System.Array.IndexOf(nums, token) > 0 ) //Проверка является ли токен чар-числом
                {
                    postfixList.Add(token);
                }

                else if (token == '(')
                {
                    opStack.Push(token);
                }
                
                else if (token == ')')
                {
                    char topToken = opStack.Pop();
                    while (topToken != '(')
                    {
                        postfixList.Add(topToken);
                        topToken = opStack.Pop();
                    }
                }
                else
                {
                    while (opStack.Any())
                    {
                        if (priority[opStack.Peek()] >= priority[token]) // ошибка peek() on empty stack
                        {
                            postfixList.Add(opStack.Pop());
                        }

                        break;
                    }
                    opStack.Push(token);
                 }
            }

            while (opStack.Any())
            {
                postfixList.Add(opStack.Pop());
            }
            string postfix = new string(postfixList.ToArray());
            
            // Console.WriteLine(postfix);
            
            // Вычисление выражения
            
            Stack<int> operandStack = new Stack<int>();
            List<char> tokenListFin = postfix.ToList();

            foreach (char token in tokenListFin)
            {
                if (System.Array.IndexOf(nums, token) > 0)
                {
                    operandStack.Push((int)Char.GetNumericValue(token));
                }

                int val1 = 0, val2 = 0;
                

                switch (token)
                {
                    case '*':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val1*val2);
                        break;
                    case '/':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val2/val1);
                        break;
                    case '+':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val1+val2);
                        break;
                    case '-':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val2-val1);
                        break;
                }
            }
            
            // Выталкиваем ответ из стека
            Console.WriteLine(expression + "=" + operandStack.Pop());
        }
    }
}
