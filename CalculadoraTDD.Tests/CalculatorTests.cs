using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculadoraTDD.Tests
{
    using System;
    using Domain;
    using Moq;

    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add()
        {
            var result = this.calculator.Add(2, 2);
            Assert.AreEqual(4,result);
        }

        [TestMethod]
        public void AddWithDifferentArguments()
        {
            var result = this.calculator.Add(2, 5);
            Assert.AreEqual(7,result);
        }

        [TestMethod]
        public void Substract()
        {
            var result = this.calculator.Substract(5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SubstractReturningNegative()
        {
            var result = this.calculator.Substract(3, 5);
            Assert.AreEqual(-2, result);
        }
    }
}
