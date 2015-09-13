namespace CalculadoraTDD.Tests
{
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MathParserTests
    {
        private MathParser parser;
        private MathLexer lexer;

        [TestInitialize]
        public void SetUp()
        {
            var expressionValidator = new ExpressionValidator();
            var expressionFixer = new ExpressionFixer(expressionValidator);
            this.lexer = new MathLexer(expressionValidator, expressionFixer);
            var limitsValidator = new LimitsValidator(-100, 100);
            var proxy = new CalculatorProxy(limitsValidator);
            var calculator = new Calculator();
            var operatorFactory = new OperatorFactory(proxy, calculator);
            this.parser = new MathParser(this.lexer, operatorFactory);
            
        }
        [TestMethod]
        public void ProcessSimpleExpression()
        {
            Assert.AreEqual(4, this.parser.ProcessExpression("2 + 2"));
        }

        [TestMethod]
        public void ProcessExpressionWith2Operators()
        {
            Assert.AreEqual(6, this.parser.ProcessExpression("3 + 1 + 2"));
        }

        [TestMethod]
        public void ProcessExpressionWithPrecedence()
        {
            Assert.AreEqual(9, parser.ProcessExpression("3 + 3 * 2"));
        }

        [TestMethod]
        public void GetMaxPrecedence()
        {
            var tokens = this.lexer.GetTokens("3 + 3 * 2");
            var op = this.parser.GetMaxPrecedence(tokens);
            Assert.AreEqual("*", op.Token);

        }

        [TestMethod]
        public void ProcessAcceptanceExpression()
        {
            Assert.AreEqual(9, this.parser.ProcessExpression("5 + 4 * 2 / 2")); 
        }
    }
}
