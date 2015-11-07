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

            PrepInputExpression testPrep = new PrepInputExpression();

            Assert.AreEqual(testPrep.PrepareExpression(oneExpression), "0+2");
            Assert.AreEqual(testPrep.PrepareExpression(twoExpression), "2+2");
            Assert.AreEqual(testPrep.PrepareExpression(threeExpression), "0-2");
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
            Assert.AreEqual(testPrep.ValidateInputExpression(twoExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(threeExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(fourExpression).Count, 1);
            
            Assert.AreEqual(testPrep.ValidateInputExpression(fiveExpression).Count, 0);
        }

        [TestMethod]
        public void Test_ValidateInputexpression_CheckQuotes()
        {
            // incorrect
            string oneExpression = "((2+3)*2+1/10";
            string twoExpression = "(1+1)/3)+1)/4)";

            // correct
            string threeExpression = "((1+(1)))";
            string fourExpression = "1+(2+3)/5+(1+1)/2";

            PrepInputExpression testPrep = new PrepInputExpression();

            Assert.AreEqual(testPrep.ValidateInputExpression(oneExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(twoExpression).Count, 1);
            
            Assert.AreEqual(testPrep.ValidateInputExpression(threeExpression).Count, 0);
            Assert.AreEqual(testPrep.ValidateInputExpression(fourExpression).Count, 0);
        }

        [TestMethod]
        public void Test_ValidateInputExpresion_CheckRightSymbols()
        {
            // incorrect
            string oneExpression = "qwerty1+2";
            string twoExpression = "=45+2qwerty";
            string threeExpression = "(qwerty)-1+2";

            // correct
            string fourExpression = "((1+(1)))";
            string fiveExpression = "1+(2+3)/5+(1+1)/2";

            PrepInputExpression testPrep = new PrepInputExpression();

            Assert.AreEqual(testPrep.ValidateInputExpression(oneExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(twoExpression).Count, 1);
            Assert.AreEqual(testPrep.ValidateInputExpression(threeExpression).Count, 1);

            Assert.AreEqual(testPrep.ValidateInputExpression(fourExpression).Count, 0);
            Assert.AreEqual(testPrep.ValidateInputExpression(fiveExpression).Count, 0);
        }
    }
}
