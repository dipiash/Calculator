using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Calculator.Tests
{
    [TestClass]
    public class RevPolNotationTests
    {
        [TestMethod]
        public void Test_GetRPNExpression_SimpleOperator()
        {
            string oneExpression = "2+2"; // 2 2 +
            string twoExpression = "1+2-3"; // 1 2 3 - +
            
            Assert.AreEqual("2 2 +", RevPolNotation.GetRPNExpression(oneExpression));
            Assert.AreEqual("1 2 3 - +", RevPolNotation.GetRPNExpression(twoExpression));
        }

        [TestMethod]
        public void Test_GetRPNExpression_Quotes()
        {
            string oneExpression = "(2+2)*30"; // 2 2 + 30 *
            string twoExpression = "2+2/(2+3*4)"; // 2 2 2 3 4 * + / +

            Assert.AreEqual("2 2 + 30 *", RevPolNotation.GetRPNExpression(oneExpression));
            Assert.AreEqual("2 2 2 3 4 * + / +", RevPolNotation.GetRPNExpression(twoExpression));
        }

        public void Test_GetRPNExpression_EmptyString()
        {
            string emptyExpression = "";

            Assert.AreEqual("", RevPolNotation.GetRPNExpression(emptyExpression));
        }
    }
}
