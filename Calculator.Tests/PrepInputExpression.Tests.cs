using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class PrepInputExpressionTests
    {
        [TestMethod]
        public void Test_RepairStartExpression()
        {
            string oneExpression = "+2";
            string twoExpression = "2+2";
            string threeExpression = "-2";

            Assert.AreEqual(PrepInputExpression.PrepareExpression(oneExpression), "0+2");
            Assert.AreEqual(PrepInputExpression.PrepareExpression(twoExpression), "2+2");
            Assert.AreEqual(PrepInputExpression.PrepareExpression(threeExpression), "0-2");
        }

        [TestMethod]
        public void Test_ValidateInputExpression_StartEndSymbol()
        {
            string oneExpression = "2*";
            string twoExpression = "4/";
            string threeExpression = "/5*";
            string fourExpression = "*6/";
            string fiveExpression = "5*6+4-3";

            PrepInputExpression testPrep = new PrepInputExpression();

            Assert.AreEqual(testPrep.ValidateInputExpression(oneExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(twoExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(threeExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(fourExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(fiveExpression).Count, 0);
        }
    }
}
