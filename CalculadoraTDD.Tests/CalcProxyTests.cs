namespace CalculadoraTDD.Tests
{
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CalcProxyTests
    {
        [TestMethod]
        public void CoordinateValidation()
        {
            const int n1 = 10;
            const int n2 = -20;
            const int result = 1000;

            var validatorMock = new Mock<ILimitsValidator>();
            var calculatorMock = new Mock<ICalculator>();
            
            calculatorMock.Setup(x => x.Add(n1,n2)).Returns(result);            

            var calcProxy = new CalcProxy(validatorMock.Object);
            calcProxy.BinaryOperation(calculatorMock.Object.Add, n1, n2);

            validatorMock.Verify(x => x.ValidateArgs(n1, n2));
            validatorMock.Verify(x => x.ValidateResult(result));
        }

        [TestMethod]
        public void SubstractIntegracion()
        {
            var validator = new LimitsValidator(-100, 100);
            var calculator = new Calculator();
            var proxy = new CalcProxy(validator);

            var result = proxy.BinaryOperation(calculator.Substract, 5, 3);
            Assert.AreEqual(2, result);
        }
    }
}
