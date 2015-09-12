namespace CalculadoraTDD.Domain
{
    using System;
    using System.Runtime.InteropServices;

    public class LimitsValidator : ILimitsValidator
    {
        public LimitsValidator(int lowerLimit, int upperLimit)
        {
            this.LowerLimit = lowerLimit;
            this.UpperLimit = upperLimit;
        }

        public int LowerLimit { get; set; }

        public int UpperLimit { get; set; }

        public void ValidateArgs(int n1, int n2)
        {
            this.BreakIfOverflows(n1, "First argument exceeds limits");
            this.BreakIfOverflows(n2, "Second argument exceeds limits");
        }

        public void ValidateResult(int result)
        {
            this.BreakIfOverflows(result, "Result exceeds limits");
        }
        private void BreakIfOverflows(int arg, string msg)
        {
            if (this.ValueExceedsLimits(arg))
                throw new OverflowException(msg);
        }

        private bool ValueExceedsLimits(int arg)
        {
            return arg > this.UpperLimit || arg < this.LowerLimit;
        }
    }
}
