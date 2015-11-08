using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string threeExpression = "1*2/3"; // 1 2 3 / *
            string fourExpression = "1.2*2/3"; // 1 2 3 / *

            Assert.AreEqual(RevPolNotation.GetRPNExpression(oneExpression), "2 2 +");
            Assert.AreEqual(RevPolNotation.GetRPNExpression(twoExpression), "1 2 3 - +");
            Assert.AreEqual(RevPolNotation.GetRPNExpression(threeExpression), "1 2 3 / *");
            Assert.AreEqual(RevPolNotation.GetRPNExpression(fourExpression), "1.2 2 3 / *");
        }

        [TestMethod]
        public void Test_GetRPNExpression_Quotes()
        {
            string oneExpression = "(2+2)*30"; // 2 2 + 30 *
            string twoExpression = "2+2/(2+3*4)"; // 2 2 2 3 4 * + / +

            Assert.AreEqual(RevPolNotation.GetRPNExpression(oneExpression), "2 2 + 30 *");
            Assert.AreEqual(RevPolNotation.GetRPNExpression(twoExpression), "2 2 2 3 4 * + / +");
        }

        public void Test_GetRPNExpression_EmptyString()
        {
            string emptyExpression = "";

            Assert.AreEqual(RevPolNotation.GetRPNExpression(emptyExpression), "");
        }
    }
}
