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

            Assert.Equals(4, CalculateRevPolNotation.GetResult(oneExpression));
            Assert.Equals(0, CalculateRevPolNotation.GetResult(twoExpression));
            Assert.Equals(0.667, CalculateRevPolNotation.GetResult(threeExpression));
        }

        [TestMethod]
        public void Test_GetResultCalculateRPNDiffcultExpression()
        {
            string oneExpression = "2 2 + 30 *"; // 120
            string twoExpression = "2 2 2 3 4 * + / +"; // 2.143

            Assert.Equals(120, CalculateRevPolNotation.GetResult(oneExpression));
            Assert.Equals(2.143, CalculateRevPolNotation.GetResult(twoExpression));
        }
    }
}
