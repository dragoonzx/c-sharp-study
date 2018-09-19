using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data;
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
            int q = 0, j = 0;
            
            // Переводим в постфиксную форму
            foreach (char token in tokenList)
            {
                j += 1;
                if (System.Array.IndexOf(nums, token) >= 0 ) //Проверка является ли токен чар-числом
                {
                    postfixList.Add(token);  
                    q += 1;
                    
                    if (j == tokenList.Length)
                    {
                        postfixList.Add(' ');
                    }
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
                    if (q >= 1)
                    {
                        postfixList.Add(' ');
                        q = 0;
                    }

                    q = 0;
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
            
            Console.WriteLine(postfix);
            
            // Вычисление выражения
            
            Stack<int> operandStack = new Stack<int>();
            List<char> tokenListFin = postfix.ToList();
            int val1 = 0, val2 = 0, x = 0;
            string temp = "";
            
            foreach (char token in tokenListFin)
            {
                
                if (System.Array.IndexOf(nums, token) >= 0)
                {
                    operandStack.Push((int)Char.GetNumericValue(token));
                    
                }
                
                

                if (token == ' ')
                {
                    x += 1;
                    for (int i = operandStack.Count + 1; i > x; i-- )
                    {
                        temp += operandStack.Pop().ToString();
                    }
  
                    string outTemp = new string(temp.ToCharArray().Reverse().ToArray());
                    if (outTemp == "")
                    {
                        continue;
                    }
                    operandStack.Push(Int32.Parse(outTemp));
                    temp = "";
                    
                    Console.WriteLine(operandStack.Peek());
                }

                switch (token)
                {
                    case '*':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val1*val2);
                        x = operandStack.Count;
                        break;
                    case '/':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        if (val1 != 0)
                        {
                            operandStack.Push(val2 / val1);
                            x = operandStack.Count;
                        }
                        else
                        {
                            Console.WriteLine("Делить на ноль нельзя!");
                            return;
                        }
                        break;
                    case '+':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val1+val2);
                        x = operandStack.Count;
                        break;
                    case '-':
                        val1 = operandStack.Pop();
                        val2 = operandStack.Pop();
                        operandStack.Push(val2-val1);
                        x = operandStack.Count;
                        break;
                }
            }
            
            // Выталкиваем ответ из стека
            Console.WriteLine(expression + "=" + operandStack.Pop());
        }
    }
}
