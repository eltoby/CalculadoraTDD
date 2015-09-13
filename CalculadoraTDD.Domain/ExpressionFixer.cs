namespace CalculadoraTDD.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ExpressionFixer : IExpressionFixer
    {
        public IList<string> FixExpressions(IList<string> expressions)
        {
            expressions = expressions.Where(expression => !string.IsNullOrEmpty(expression)).ToList();
            
            var regex = new Regex(@"^(\s*)[\+|\-|\/|\*](\s+)");
            var endOfList = false;

            while (!endOfList)
            {
                endOfList = true;
                for (var i = 0; i < expressions.Count; i++)
                    if (regex.IsMatch(expressions[i]))
                    {
                        var exp = expressions[i];
                        exp = exp.Trim();
                        var nexExps = exp.Split(new[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        expressions[i] = nexExps[0];
                        expressions.Insert(i + 1, nexExps[1]);
                        endOfList = false;
                    }
            }
            return expressions;
        }
    }
}
