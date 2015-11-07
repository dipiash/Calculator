using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculateRevPolNotationTests
    {
        [TestMethod]
        public void Test_GetResultCalculateRPNSimpleExpression()
        {
            string oneExpression = "2 2 +"; // 4
            string twoExpression = "1 2 3 - +"; // 0
            string threeExpression = "1 2 3 / *"; // 0.667
            string fourExpression = "1 0 /"; // "Error! Division by zero."
            string fiveExpression = "1.2 3 -"; // -1.8

            Assert.AreEqual(CalculateRevPolNotation.Calculate(oneExpression), 4);
            Assert.AreEqual(CalculateRevPolNotation.Calculate(twoExpression), 0);
            Assert.AreEqual(CalculateRevPolNotation.Calculate(threeExpression), (decimal)0.667);

            try
            {
                decimal calcFour = CalculateRevPolNotation.Calculate(fourExpression);
            } catch (ExpresionExceptions e)
            {
                Assert.AreEqual(e.Message, "Error! Division by zero.");
            }

            Assert.AreEqual(CalculateRevPolNotation.Calculate(fiveExpression), (decimal)-1.8);
        }

        [TestMethod]
        public void Test_GetResultCalculateRPNDiffcultExpression()
        {
            string oneExpression = "2 2 + 30 *"; // 120
            string twoExpression = "2 2 2 3 4 * + / +"; // 2.143

            Assert.AreEqual(CalculateRevPolNotation.Calculate(oneExpression), 120);
            Assert.AreEqual(CalculateRevPolNotation.Calculate(twoExpression), (decimal)2.143);
        }
    }
}
