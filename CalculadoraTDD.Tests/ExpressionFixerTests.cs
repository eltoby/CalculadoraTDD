namespace CalculadoraTDD.Tests
{
    using System.Collections.Generic;
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpressionFixerTests
    {
        [TestMethod]
        public void SplitExpressionWhenOperatorAtEnd()
        {
            var validator = new MathRegex();
            var fixer = new ExpressionFixer(validator);
            var expressions = new List<string> {"2 +"};
            var result = fixer.FixExpressions(expressions);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains("2"));
            Assert.IsTrue(result.Contains("+"));
        }
    }
}
