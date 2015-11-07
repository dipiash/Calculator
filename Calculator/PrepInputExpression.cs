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
