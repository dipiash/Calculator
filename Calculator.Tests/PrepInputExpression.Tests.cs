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
            // incorrect
            string oneExpression = "2*";
            string twoExpression = "4/";
            string threeExpression = "/5*";
            string fourExpression = "*6/";
            
            // correct
            string fiveExpression = "5*6+4-3";

            PrepInputExpression testPrep = new PrepInputExpression();

            Assert.AreEqual(testPrep.ValidateInputExpression(oneExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(twoExpression).Count, 2);
            Assert.AreEqual(testPrep.ValidateInputExpression(threeExpression).Count, 3);
            Assert.AreEqual(testPrep.ValidateInputExpression(fourExpression).Count, 4);

            // count errors in _logError should be 4, because fiveExpression is correct
            Assert.AreEqual(testPrep.ValidateInputExpression(fiveExpression).Count, 4);
        }
    }
}
