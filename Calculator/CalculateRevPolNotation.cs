using System;
using System.Collections.Generic;
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
                if (decimal.TryParse(token, out tmpNumber))
                {
                    stack.Push(tmpNumber);
                }
                else
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
                                stack.Push(Div(stack.Pop(), tmpNumber));
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
                            Console.WriteLine("Error in CalculateRPN(string) Method!");
                            break;
                    }
                }
            }

            result = RoundResult(stack.Pop());

            return result;
        }

        private static decimal RoundResult(decimal inputResult)
        {
            decimal result = decimal.Zero;

            result = inputResult;
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
