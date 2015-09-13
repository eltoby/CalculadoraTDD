namespace CalculadoraTDD.Domain
{
    public interface IExpressionValidator
    {
        bool IsValidExpression(string expression);
        bool IsNumberAndOperator(string expression);
    }
}