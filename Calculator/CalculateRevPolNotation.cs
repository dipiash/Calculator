﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Class for calculate RPN expression.
    /// </summary>
    public class CalculateRevPolNotation
    {
        /// <summary>
        /// Main method for calculate expression
        /// </summary>
        /// <param name="inputRPNExpression">RPN expression</param>
        /// <returns>decimal</returns>
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
                else if (Constants.SIMPLE_OPERATORS.IndexOf(token) != -1)
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
                                    throw new ExpresionExceptions("Error! Division by zero.");
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
                            throw new ExpresionExceptions("Calculate error!");
                    }
                }
                else
                {
                    throw new ExpresionExceptions("Out of range!");
                }
            }

            if (stack.Count != 0)
            {
                result = RoundResult(stack.Pop());
                return result;
            }
            else
            {
                throw new ExpresionExceptions("Error! You input incorrect expression.");
            }
        }

        /// <summary>
        /// Method for check and extract two values from stack.
        /// </summary>
        /// <param name="st">stack</param>
        /// <returns>decimal array</returns>
        private static decimal[] ContainValFromStack(Stack<decimal> st)
        {
            decimal[] twoVal = new decimal[2];

            if (st.Count != 0)
            {
                twoVal[0] = st.Pop();
            } else
            {
                throw new ExpresionExceptions("Error! You input incorrect expression.");
            }

            if (st.Count != 0)
            {
                twoVal[1] = st.Pop();
            }
            else
            {
                throw new ExpresionExceptions("Error! You input incorrect expression.");
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
            decimal result = 0;

            try
            {
                result = decimal.Add(a, b);
            }
            catch (OverflowException)
            {
                throw new ExpresionExceptions("Out of range!");
            }

            return result;
        }

        private static decimal Sub(decimal a, decimal b)
        {
            decimal result = 0;

            try
            {
                result = decimal.Subtract(a, b);
            }
            catch (OverflowException)
            {
                throw new ExpresionExceptions("Out of range!");
            }

            return result;
        }

        private static decimal Div(decimal a, decimal b)
        {
            decimal result = 0;

            try
            {
                result = decimal.Divide(a, b);
            }
            catch (OverflowException)
            {
                throw new ExpresionExceptions("Out of range!");
            }

            return result;
        }

        private static decimal Mul(decimal a, decimal b)
        {
            decimal result = 0;

            try
            {
                result = decimal.Multiply(a, b);
            }
            catch (OverflowException)
            {
                throw new ExpresionExceptions("Out of range!");
            } 

            return result;
        }
    }
}
