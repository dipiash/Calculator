using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculateRevPolNotationTests
    {
        [TestMethod]
        public void Test_GetResultCalculateRPN_SimpleExpression()
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
        public void Test_GetResultCalculateRPN_DiffcultExpression()
        {
            string oneExpression = "2 2 + 30 *"; // 120
            string twoExpression = "2 2 2 3 4 * + / +"; // 2.143
            string threeExpression = "2 * / - +"; // Error in RPN expression. Calculate error!

            Assert.AreEqual(CalculateRevPolNotation.Calculate(oneExpression), 120);
            Assert.AreEqual(CalculateRevPolNotation.Calculate(twoExpression), (decimal)2.143);

            try
            {
                decimal resultExpression = CalculateRevPolNotation.Calculate(threeExpression);
            } 
            catch (ExpresionExceptions e)
            {
                Assert.AreEqual(e.Message, "Error! You input incorrect expression.");
            }
        }

        [TestMethod]
        public void Test_GetResultCalculateRPN_BigDecimal()
        {
            string oneExpression = "9999999999999999999999999 99999999999999999999999 *";

            try
            {
                decimal resultExpression = CalculateRevPolNotation.Calculate(oneExpression);
            }
            catch (OverflowException e)
            {
                Assert.AreEqual(e.Message, "Out of range!");
            }
        }
    }
}
