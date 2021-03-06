﻿using System;
using System.Collections.Generic;
using Calculator;

namespace CalcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input expression. Use only [ /*-+.() ].");
                string expression = Console.ReadLine();

                if (expression.Length == 0)
                {
                    Console.WriteLine("Error! You should input expression!");
                    continue;
                }

                PrepInputExpression prepare = new PrepInputExpression();
                string tmpExpression = prepare.PrepareExpression(expression);
                List<string> errors = prepare.ValidateInputExpression(tmpExpression);
                int countErrors = errors.Count;

                if (countErrors != 0)
                {
                    Console.WriteLine("\nFound {0} error.", countErrors);
                    int item;
                    for (item = 0; item < countErrors; item++)
                    {
                        Console.WriteLine(errors[item]);
                    }
                }
                else
                {
                    tmpExpression = RevPolNotation.GetRPNExpression(tmpExpression);
                    try
                    {
                        decimal result = CalculateRevPolNotation.Calculate(tmpExpression);

                        Console.WriteLine("\nEvaluate expression: {0}", expression);
                        Console.WriteLine("result: {0}", result);
                    }
                    catch (ExpresionExceptions e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                }
            }
        }
    }
}
