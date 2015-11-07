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
    }
}
