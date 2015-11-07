using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculateRevPolNotation
    {
        public static decimal Calculate(string inputRPNExpression)
        {
            string[] items = inputRPNExpression.Split(' ');
            Stack<decimal> stack = new Stack<decimal>();
            decimal tmpNumber = decimal.Zero;
            decimal result = decimal.Zero;

            foreach (string token in items)
            {
                if (decimal.TryParse(token, NumberStyles.Any, new CultureInfo("en-US"), out tmpNumber))
                {
                    stack.Push(tmpNumber);
                }
                else
                {
                    try
                    {
                        switch (token)
                        {
                            case "*":
                                {
                                    stack.Push(Mul(stack.Pop(), stack.Pop()));
                                    break;
                                }
                            case "/":
                                {
                                    tmpNumber = stack.Pop();
                                    if (tmpNumber != 0 && tmpNumber != (decimal)0.0)
                                    {
                                        stack.Push(Div(stack.Pop(), tmpNumber));
                                    }
                                    else
                                    {
                                        new ExpresionExceptions("Error! Division by zero.");
                                    }
                                    break;
                                }
                            case "+":
                                {
                                    stack.Push(Add(stack.Pop(), stack.Pop()));
                                    break;
                                }
                            case "-":
                                {
                                    tmpNumber = stack.Pop();
                                    stack.Push(Sub(stack.Pop(), tmpNumber));
                                    break;
                                }
                            default:
                                new ExpresionExceptions("Error in RPN expression. Calculate error!");
                                break;
                        }
                    } catch (ExpresionExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        return -1;
                    }
                }
            }

            result = RoundResult(stack.Pop());

            return result;
        }

        private static decimal RoundResult(decimal inputResult)
        {
            decimal result = inputResult;

            if (result != 0)
            {
                result = decimal.Parse(result.ToString("#.###"));
            }
            else
            {
                result = 0;
            }

            return result;
        }

        private static decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        private static decimal Sub(decimal a, decimal b)
        {
            return a - b;
        }

        private static decimal Div(decimal a, decimal b)
        {
            return a / b;
        }

        private static decimal Mul(decimal a, decimal b)
        {
            return a * b;
        }
    }
}
