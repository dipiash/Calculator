using System;
namespace Calculator
{
    public class ExpresionExceptions : ApplicationException
    {
        public ExpresionExceptions() { }

        public ExpresionExceptions(string message) : base(message) { }
    }
}
