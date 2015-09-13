namespace CalculadoraTDD.Domain
{
    using System;

    public class OperatorFactory : IOperatorFactory
    {
        private readonly ICalculatorProxy proxy;
        private readonly ICalculator calculator;

        public OperatorFactory(ICalculatorProxy proxy, ICalculator calculator)
        {
            this.proxy = proxy;
            this.calculator = calculator;
        }

        public MathOperator Create(MathToken token)
        {
            switch (token.Token)
            {
                case "+":
                    return new AddOperator(token, this.proxy, this.calculator);
                case "-":
                    return new SubstractOperator(token, this.proxy, this.calculator);
                case "*":
                    return new MultiplyOperator(token, this.proxy, this.calculator);
                case "/":
                    return new DivideOperator(token, this.proxy, this.calculator);
                default:
                    throw new ArgumentException("Not recognized operator");
            }

        }
    }
}