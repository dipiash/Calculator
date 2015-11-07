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
        public void Test_CheckStartEndExpression()
        {
            string oneExpression = "2*";
            string twoExpression = "4/";
            string threeExpression = "/5*";
            string fourExpression = "*6/";
            string fiveExpression = "5*6+4-3";

            Assert.AreEqual(PrepInputExpression.CheckStartEndExpression(oneExpression), false);
            Assert.AreEqual(PrepInputExpression.CheckStartEndExpression(twoExpression), false);
            Assert.AreEqual(PrepInputExpression.CheckStartEndExpression(threeExpression), false);
            Assert.AreEqual(PrepInputExpression.CheckStartEndExpression(fourExpression), false);
            Assert.AreEqual(PrepInputExpression.CheckStartEndExpression(fiveExpression), true);
        }
    }
}
