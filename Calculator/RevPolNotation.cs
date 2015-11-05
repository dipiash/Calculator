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
            // evaluate some methods

            return _outputExpression;
        }

        private static bool IsSimpleOperator(char inputOperator)
        {
            // some code for check
            if (SIMPLE_OPERATORS.IndexOf(inputOperator) != -1)
            {
                return true;
            }

            return false;
        }

        private static byte GetPriorytyForItem(string inputItem)
        {
            // some code for check

            return 0;
        }

        private static string ConvertExpressionToRPN(string inputExpression)
        {
            // some code for converting

            return "";
        }
    }
}
