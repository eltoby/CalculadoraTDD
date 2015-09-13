namespace CalculadoraTDD.Domain
{
    public class AddOperator : MathOperator
    {
        public AddOperator(MathToken token, ICalculatorProxy proxy, ICalculator calculator) : base(token, 1, proxy, calculator.Add)
        {
        }
    }
}
