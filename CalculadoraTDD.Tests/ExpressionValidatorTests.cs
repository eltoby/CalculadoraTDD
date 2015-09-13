namespace CalculadoraTDD.Tests
{
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class ExpressionValidatorTests
    {
        private ExpressionValidator expressionValidator;

        [TestInitialize]
        public void SetUp()
        {
            this.expressionValidator = new ExpressionValidator();
        }

        [TestMethod]
        public void ValidateMoreThanOneDigitExpression()
        {
            const string expression = "25 + 52";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateSimpleExpressionWithMultipleOperators()
        {
            foreach (var op in "+-*/".ToCharArray())
            {
                var expression = "2 " + op + " 2";
                var result = this.expressionValidator.IsValidExpression(expression);
                Assert.IsTrue(result, string.Format("Failure with operator {0}", op));
            }
        }

        [TestMethod]
        public void ValidateWithSpaces()
        {
            const string expression = "2   +   2";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailsWithNoSpaces()
        {
            const string expression = "2+2";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateComplexExpression()
        {
            const string expression = "2 + 7 - 2 * 4";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateComplexWrongExpression()
        {
            const string expression = "2 + 7 - 2 a 4";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateWithNegativeNumbers()
        {
            const string expression = "-7 + 1";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateSuperComplexExpression()
        {
            const string expression = "-7 - -1 * 2 / 3 + -5";
            var result = this.expressionValidator.IsValidExpression(expression);
            Assert.IsTrue(result);
        }
    }
}
