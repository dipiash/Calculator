using System;
namespace Calculator
{
    /// <summary>
    /// Simple custom class for handling exceptions for our application.
    /// </summary>
    public class ExpresionExceptions : ApplicationException
    {
        public ExpresionExceptions() { }

        public ExpresionExceptions(string message) : base(message) { }
    }
}
