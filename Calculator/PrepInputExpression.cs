﻿using System;
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
        public string PrepareExpression(string inputExpression)
        {
            string tmpString = inputExpression;
            tmpString = tmpString.Trim();
            tmpString = RepairStartExpression(tmpString);

            _outputexpression = tmpString;

            return _outputexpression;
        }

        public List<string> ValidateInputExpression(string inputexpression)
        {
            _logErros = new List<string>();

            _logErros = CheckStartEndExpression(inputexpression);
            _logErros = CheckQuotes(inputexpression);

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
        private static List<string> CheckQuotes(string inputExpression)
        {
            int countOpenQuotes = 0;
            int countCloseQuotes = 0;
            int symbolNumber;

            for (symbolNumber = 0; symbolNumber < inputExpression.Length; symbolNumber++)
            {
                if (inputExpression[symbolNumber] == '(')
                {
                    countOpenQuotes++;
                }

                if (inputExpression[symbolNumber] == ')')
                {
                    countCloseQuotes++;
                }
            }

            if (countOpenQuotes != countCloseQuotes)
            {
                _logErros.Add("Error! Check your open and close quotes.");
            }

            return _logErros;
        }

        // check digits|operators|quotes

        // Check sequence
            // ++|+-|+*|+/
            // --|-+|-*|-/
            // **|*+|*-|*/
            // //|/-|/+|/*
            // ()
    }
}
