using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ExpresionExceptions : ApplicationException
    {
        public ExpresionExceptions() { }

        public ExpresionExceptions(string message) : base(message) { }
    }
}
