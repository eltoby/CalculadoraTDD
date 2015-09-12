namespace CalculadoraTDD.Domain
{
    public interface ILimitsValidator
    {
        void ValidateArgs(int n1, int n2);
        void ValidateResult(int result);
    }
}
