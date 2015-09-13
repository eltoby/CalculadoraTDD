namespace CalculadoraTDD.Domain
{
    public class MultiplyOperator : MathOperator
    {
        public MultiplyOperator(MathToken token, ICalculatorProxy proxy, ICalculator calculator) : base(token, 2, proxy, calculator.Multiply)
        {
        }
    }
}
