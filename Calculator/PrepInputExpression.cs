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
        private static List<string> _logErros = new List<string>();
        public static string PrepareExpression(string inputExpression)
        {
            string tmpString = inputExpression;
            tmpString = tmpString.Trim();
            tmpString = RepairStartExpression(tmpString);

            _outputexpression = tmpString;

            return _outputexpression;
        }

        public List<string> ValidateInputExpression(string inputexpression)
        {
            _logErros = CheckStartEndExpression(inputexpression);

            return _logErros;
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
        private static List<string> CheckStartEndExpression(string inputExpression)
        {
            char startSymbol = inputExpression[0];
            char endSymbol = inputExpression[inputExpression.Length - 1];

            if (startSymbol == '*' || startSymbol == '/' || endSymbol == '*' || endSymbol == '/')
            {
                _logErros.Add("Error! Checked start or end symbol in your expression.");
            }

            return _logErros;
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
