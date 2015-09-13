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

        public bool IsNumberAndOperator(string exp)
        {
            var startsWithOperatorRegex = new Regex(@"^(\s*)[\+|\-|\/|\*](\s+)");
            var endsWithOperatorRegex = new Regex(@"(\s+)[\+|\-|\/|\*](\s*)$");
            return startsWithOperatorRegex.IsMatch(exp) || endsWithOperatorRegex.IsMatch(exp);
        }

    }
}