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
            // some code for prepare

            return _outputexpression;
        }

        // Add zero to end|start string, if we have simple operator at start|end
        // Add zero to start string, if we have simple operator [+-] is first symbol
        private static string RepairStartExpression(string inputExpression)
        {
            char startSimbol = inputExpression[0];

            if (startSimbol == '+' || startSimbol == '-')
            {
                inputExpression = "0" + inputExpression;
            }

            return inputExpression;
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
