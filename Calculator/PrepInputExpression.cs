using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PrepInputExpression
    {
        private static string _outputexpression = string.Empty;
        private static string[] _logErros = { };
        public static string PrepareExpression(string inputExpression)
        {
            string tmpString = inputExpression;
            tmpString = tmpString.Trim();
            tmpString = RepairStartExpression(tmpString);

            _outputexpression = tmpString;

            return _outputexpression;
        }

        // Add zero to start string, if we have simple operator [+-] is first symbol
        private static string RepairStartExpression(string inputExpression)
        {
            char startSymbol = inputExpression[0];

            if (startSymbol == '+' || startSymbol == '-')
            {
                inputExpression = "0" + inputExpression;
            }

            return inputExpression;
        }

        // Check start|end symbol for Expression [/*]EXPRESSION[*/]
        public static bool CheckStartEndExpression(string inputExpression)
        {
        }

        // Check quotes

        // check digits|operators|quotes

        // Trim

        // Check sequence
            // ++|+-|+*|+/
            // --|-+|-*|-/
            // **|*+|*-|*/
            // //|/-|/+|/*
            // ()
    }
}
