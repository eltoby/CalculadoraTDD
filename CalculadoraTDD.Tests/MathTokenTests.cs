namespace CalculadoraTDD.Tests
{
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MathTokenTests
    {
        [TestMethod]
        public void NumberIsNotOperator()
        {
            var token = new MathToken("33", 0);
            Assert.IsFalse(token.IsOperator());
        }

        [TestMethod]
        public void IsOperator()
        {
            var add = new MathToken("+", 0);
            var substract = new MathToken("-", 0);
            var multiply = new MathToken("-", 0);
            var divide = new MathToken("/", 0);

            Assert.IsTrue(add.IsOperator());
            Assert.IsTrue(substract.IsOperator());
            Assert.IsTrue(multiply.IsOperator());
            Assert.IsTrue(divide.IsOperator());
        }

        [TestMethod]
        public void IntValue()
        {
            var token = new MathToken("7", 0);
            Assert.AreEqual(7, token.IntValue);
        }
    }
}
