namespace CalculadoraTDD.Domain
{
    public class DivideOperator : MathOperator
    {
        public DivideOperator(MathToken token, ICalculatorProxy proxy, ICalculator calculator) : base(token, 2, proxy, calculator.Divide)
        {
        }
    }
}
