namespace CalculadoraTDD.Domain
{
    public class SubstractOperator : MathOperator
    {
        public SubstractOperator(MathToken token, ICalculatorProxy proxy, ICalculator calculator) : base(token, 1, proxy, calculator.Substract)
        {
        }
    }
}
