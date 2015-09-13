namespace CalculadoraTDD.Domain
{
    public interface IMathRegex
    {
        bool IsValidExpression(string expression);
        
        bool IsNumberAndOperator(string expression);
    }
}