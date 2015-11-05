using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RevPolNotation
    {
        private const string SIMPLE_OPERATORS = "+-*/()";

        private static string _inputExpression = string.Empty;
        private static string _outputExpression = string.Empty;

        public static string GetRPNExpression(string inputExpression)
        {
            _outputExpression = ConvertExpressionToRPN(inputExpression);

            return _outputExpression;
        }

        private static bool IsSimpleOperator(char inputOperator)
        {
            if (SIMPLE_OPERATORS.IndexOf(inputOperator) != -1)
            {
                return true;
            }

            return false;
        }

        private static byte GetPriorytyForItem(string inputItem)
        {
            // Item priority (simple operators)
            // * -      HIGH      4 4
            // + -      MIDDLE    3 3
            // ( )      LOW       1 2
            
            switch(inputItem)
            {
                case "/": return 4;
                case "*": return 4;
                case "+": return 3;
                case "-": return 3;
                case ")": return 2;
                case "(": return 1;
                default: return 0;
            }
        }

        private static string ConvertExpressionToRPN(string inputExpression)
        {
            // PSEUDO CODE

            // While we have characters
                // Read symbol
                // If symbol is number
                    // Add to output string
                // If symbol is open quote
                    // Add to stack
                // If symbol is close quote
                    // While (is not open quote from stack)
                        // push elements to output string
                // If symbol is simple operator
                    // Check priority   
                        // push top elements to output string
                    // push simple operator to stack
                // If end of input string - push all symbols to output string

            return "";
        }
    }
}
