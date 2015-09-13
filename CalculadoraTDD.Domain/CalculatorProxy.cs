namespace CalculadoraTDD.Domain
{
    public class CalculatorProxy : ICalculatorProxy
    {
        private readonly ILimitsValidator validator;

        public delegate int SingleBinaryOperation(int n1, int n2);
        public CalculatorProxy(ILimitsValidator validator)
        {
            this.validator = validator;
        }

        public int BinaryOperation(SingleBinaryOperation binaryOperation, int n1, int n2)
        {
            this.validator.ValidateArgs(n1, n2);
            var result = binaryOperation.Invoke(n1, n2);
            this.validator.ValidateResult(result);
            return result;
        }
    }

    public interface ICalculatorProxy
    {
        int BinaryOperation(CalculatorProxy.SingleBinaryOperation binaryOperation, int n1, int n2);
    }
}
