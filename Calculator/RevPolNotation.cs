using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class RevPolNotation
    {
        private static string _inputExpression = string.Empty;
        private static string _outputExpression = string.Empty;

        public static string GetRPNExpression(string inputExpression)
        {
            _outputExpression = ConvertExpressionToRPN(inputExpression);

            return _outputExpression;
        }

        private static bool IsSimpleOperator(char inputOperator)
        {
            if (Constants.SIMPLE_OPERATORS.IndexOf(inputOperator) != -1)
            {
                return true;
            }

            return false;
        }

        private static byte GetPriorytyForItem(string inputItem)
        {
            // Item priority (simple operators)
            // * /      HIGH      4 5
            // + -      MIDDLE    2 3
            // ( )      LOW       0 1
            
            switch(inputItem)
            {
                case "/": return 5;
                case "*": return 4;
                case "-": return 3;
                case "+": return 2;
                case ")": return 1;
                case "(": return 0;
                default: return 6;
            }
        }

        private static string ConvertExpressionToRPN(string inputExpression)
        {
            string output = string.Empty;
            Stack<string> operatorStack = new Stack<string>();

            int countChars;
            int legthInputExpression = inputExpression.Length;

            for (countChars = 0; countChars < legthInputExpression; countChars++)
            {
                if (Char.IsDigit(inputExpression[countChars]) || inputExpression[countChars] == '.')
                {
                    while(!IsSimpleOperator(inputExpression[countChars]))
                    {
                        output += inputExpression[countChars];
                        countChars++;

                        if (countChars == legthInputExpression)
                        {
                            break;
                        }
                    }

                    output += " ";
                    countChars--;
                }

                if (IsSimpleOperator(inputExpression[countChars]))
                {
                    if (inputExpression[countChars] == '(')
                    {
                        operatorStack.Push(inputExpression[countChars].ToString());
                    }

                    if (inputExpression[countChars] == ')')
                    {
                        string itemsAtBracket = operatorStack.Pop();

                        while (itemsAtBracket != "(")
                        {
                            output += itemsAtBracket + " ";
                            itemsAtBracket = operatorStack.Pop();
                        }
                    }

                    if (inputExpression[countChars] != '(' && inputExpression[countChars] != ')')
                    {
                         if (operatorStack.Count() > 0 && 
                                GetPriorytyForItem(inputExpression[countChars].ToString()) <= GetPriorytyForItem(operatorStack.Peek()))
                            {
                                output += operatorStack.Pop() + " ";
                            }

                         operatorStack.Push(inputExpression[countChars].ToString());
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                output += operatorStack.Pop() + " ";
            }        

            return output.Trim();
        }
    }
}
