﻿using System;
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
                                    decimal[] values = ContainValFromStack(stack);

                                    stack.Push(Mul(values[0], values[1]));
                                    break;
                                }
                            case "/":
                                {
                                    decimal[] values = ContainValFromStack(stack);

                                    tmpNumber = values[0];
                                    if (tmpNumber != 0 && tmpNumber != (decimal)0.0)
                                    {
                                        stack.Push(Div(values[1], tmpNumber));
                                    }
                                    else
                                    {
                                        new ExpresionExceptions("Error! Division by zero.");
                                    }
                                    break;
                                }
                            case "+":
                                {
                                    decimal[] values = ContainValFromStack(stack);

                                    stack.Push(Add(values[0], values[1]));
                                    break;
                                }
                            case "-":
                                {
                                    decimal[] values = ContainValFromStack(stack);

                                    tmpNumber = values[0];
                                    stack.Push(Sub(values[1], tmpNumber));
                                    break;
                                }
                            default:
                                new ExpresionExceptions("Error in RPN expression. Calculate error!");
                                break;
                        }
                    }
                    catch (ExpresionExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        return -1;
                    }
                }
            }

            result = RoundResult(stack.Pop());

            return result;
        }

        private static decimal[] ContainValFromStack(Stack<decimal> st)
        {
            decimal[] twoVal = new decimal[2];

            if (st.Count != 0)
            {
                twoVal[0] = st.Pop();
            } else
            {
                new ExpresionExceptions("Error! You input incorrect expression.");
            }

            if (st.Count != 0)
            {
                twoVal[1] = st.Pop();
            }
            else
            {
                new ExpresionExceptions("Error! You input incorrect expression.");
            }

            return twoVal;
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
