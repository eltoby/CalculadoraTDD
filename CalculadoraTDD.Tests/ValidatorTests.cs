namespace CalculadoraTDD.Tests
{
    using System;
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidatorTests
    {
        private LimitsValidator validator;

        [TestInitialize]
        public void SetUp()
        {
            this.validator = new LimitsValidator(-100, 100);
        }

        [TestMethod]
        public void SetAndGetLimits()
        {
            Assert.AreEqual(-100, this.validator.LowerLimit);
            Assert.AreEqual(100, this.validator.UpperLimit);
        }

        [TestMethod]
        public void ArgumentsExceedLimits()
        {
            try
            {
                this.validator.ValidateArgs(this.validator.UpperLimit + 1, this.validator.LowerLimit - 1);
                Assert.Fail("Exception not thrown when arguments exceed limits");
            }
            catch (OverflowException)
            {
                // Ok, the SUT works as expected
            }
        }

        [TestMethod]
        public void ArgumentsExceedLimitsInverse()
        {
            try
            {
                this.validator.ValidateArgs(this.validator.LowerLimit - 1, this.validator.UpperLimit + 1);
                Assert.Fail("Exception not thrown when arguments exceed limits");
            }
            catch (OverflowException)
            {
                // Ok, the SUT works as expected
            }
        }

        [TestMethod]
        public void ResultExceedingUpperLimit()
        {
            try
            {
                this.validator.ValidateResult(150);
                Assert.Fail("Exception not thrown when exceeding upper limit");
            }
            catch (OverflowException)
            {
                // Ok, the SUT works as expected
            }
        }

    }
}
