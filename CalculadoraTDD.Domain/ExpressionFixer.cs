namespace CalculadoraTDD.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ExpressionFixer : IExpressionFixer
    {
        private readonly IMathRegex expressionValidator;

        public ExpressionFixer(IMathRegex expressionValidator)
        {
            this.expressionValidator = expressionValidator;
        }

        public IList<string> FixExpressions(IList<string> expressions)
        {
            expressions = RemoveEmptyExpressions(expressions);
            
            var listHasChanged = true;
            while (listHasChanged)
            {
                listHasChanged = false;
                for (var i = 0; i < expressions.Count; i++)
                {
                    var exp = expressions[i];
                    if (!this.expressionValidator.IsNumberAndOperator(exp)) continue;
                    var splitted = RemoveEmptyExpressions(SplitByOperator(exp));
                    expressions.RemoveAt(i);
                    
                    foreach (var newExp in splitted)
                    {
                        expressions.Add(newExp.Trim());
                        i++;
                    }
                    listHasChanged = true;
                }
            }
            return expressions;
        }

        private static List<string> RemoveEmptyExpressions(IEnumerable<string> expressions)
        {
            return expressions.Where(expression => !string.IsNullOrEmpty(expression.Trim())).ToList();
        }

        private static IEnumerable<string> SplitByOperator(string exp)
        {
            var expressions = Regex.Split(exp, @"([\+|\-|\/|\*])");
            return expressions;
        }
    }
}
