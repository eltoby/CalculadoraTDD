namespace CalculadoraTDD.Domain
{
    public abstract class MathOperator : MathToken
    {
        private readonly ICalculatorProxy proxy;
        private readonly CalculatorProxy.SingleBinaryOperation operation;

        protected MathOperator(MathToken token, int precedence, ICalculatorProxy proxy, CalculatorProxy.SingleBinaryOperation operation)
            : base(token.Token, token.Index)
        {
            this.Precedence = precedence;
            this.proxy = proxy;
            this.operation = operation;
        }

        public int Precedence { get; set; }

        public int Resolve(MathToken n1, MathToken n2)
        {
            var result = this.proxy.BinaryOperation(this.operation, n1.IntValue, n2.IntValue);
            return result;
        }

    }
}