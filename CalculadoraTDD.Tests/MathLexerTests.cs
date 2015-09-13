namespace CalculadoraTDD.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MathLexerTests
    {
        private MathLexer lexer;

        [TestInitialize]
        public void SetUp()
        {
            var validator = new ExpressionValidator();
            var expressionFixer = new ExpressionFixer();
            this.lexer = new MathLexer(validator, expressionFixer);
        }

        [TestMethod]
        public void GetTokens()
        {
            var tokens = this.lexer.GetTokens("2 + 2");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual("2", tokens[0].Token);
            Assert.AreEqual("+", tokens[1].Token);
            Assert.AreEqual("2", tokens[2].Token);
        }

        [TestMethod]
        public void GetTokensLongExpression()
        {
            var tokens = this.lexer.GetTokens("2 - 1 + 3");
            Assert.AreEqual(5, tokens.Count);
            Assert.AreEqual("+", tokens[3].Token);
            Assert.AreEqual("3", tokens[4].Token);

        }

        [TestMethod]
        public void GetTokensWithWrongExpression()
        {
            const string expression = "2 - 1++ 3";

            try
            {
                this.lexer.GetTokens(expression);
                Assert.Fail("Exception not raised");
            }
            catch (InvalidOperationException)
            {
                // Ok, Works correctly
            }
        }

        [TestMethod]
        public void GetTokensWithSpaces()
        {
            var tokens = this.lexer.GetTokens("2 +   2");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual("2", tokens[0].Token);
            Assert.AreEqual("+", tokens[1].Token);
            Assert.AreEqual("2", tokens[2].Token);
        }

        [TestMethod]
        public void GetExpressionsWith1Parenthesis()
        {
            var expressions = this.lexer.GetExpressions("(2 + 2)");
            Assert.AreEqual(1, expressions.Count);
            Assert.AreEqual("2 + 2", expressions[0]);
        }

        [TestMethod]
        public void GetNestedExpressions()
        {
            const string expression = "((2 + 1) + 2)";
            var expressions = this.lexer.GetExpressions(expression);
            Assert.AreEqual(3, expressions.Count);

            foreach (var exp in expressions)
            {
                if (exp != "2 + 1" && exp != "+" && exp != "2")
                    Assert.Fail("Wrong expression split");
            }

        }
    }
}
