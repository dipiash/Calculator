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

            Assert.AreEqual(4, CalculateRevPolNotation.Calculate(oneExpression));
            Assert.AreEqual(0, CalculateRevPolNotation.Calculate(twoExpression));
            Assert.AreEqual(0.667, CalculateRevPolNotation.Calculate(threeExpression));
        }

        [TestMethod]
        public void Test_GetResultCalculateRPNDiffcultExpression()
        {
            string oneExpression = "2 2 + 30 *"; // 120
            string twoExpression = "2 2 2 3 4 * + / +"; // 2.143

            Assert.AreEqual(120, CalculateRevPolNotation.Calculate(oneExpression));
            Assert.AreEqual(2.143, CalculateRevPolNotation.Calculate(twoExpression));
        }
    }
}
