namespace CalculadoraTDD.Domain
{
    using System.Text.RegularExpressions;

    public class ExpressionValidator : IExpressionValidator
    {
        public bool IsValidExpression(string expression)
        {
            var regex = new Regex(@"^-{0,1}\d+((\s+)[\+|\-|\/|\*](\s+)-{0,1}\d+)+$");
            return regex.IsMatch(expression, 0);
        }        
    }

    public interface IExpressionValidator
    {
        bool IsValidExpression(string expression);
    }
}