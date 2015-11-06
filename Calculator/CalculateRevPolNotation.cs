using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculateRevPolNotation
    {
        private static decimal _result = decimal.Zero;
        public static decimal Calculate(string inputRPNExpression)
        {
            return _result;
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
