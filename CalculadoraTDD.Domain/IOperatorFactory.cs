namespace CalculadoraTDD.Domain
{
    public interface IOperatorFactory
    {
        MathOperator Create(MathToken token);
    }
}