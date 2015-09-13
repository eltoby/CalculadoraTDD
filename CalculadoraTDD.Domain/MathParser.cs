namespace CalculadoraTDD.Domain
{
    using System.Collections.Generic;
    using System.Globalization;

    public class MathParser
    {
        private readonly IMathLexer lexer;
        private readonly IOperatorFactory operatorFactory;

        public MathParser(IMathLexer lexer, IOperatorFactory operatorFactory)
        {
            this.lexer = lexer;
            this.operatorFactory = operatorFactory;
        }

        public int ProcessExpression(string expression)
        {
            var tokens = this.lexer.GetTokens(expression);

            while (tokens.Count > 1)
            {
                var op = this.GetMaxPrecedence(tokens);
                var n1 = tokens[op.Index - 1];
                var n2 = tokens[op.Index + 1];
                var result = op.Resolve(n1, n2);
                tokens[op.Index - 1] = new MathToken(result.ToString(CultureInfo.InvariantCulture), op.Index - 1);
                tokens.RemoveAt(op.Index);
                tokens.RemoveAt(op.Index);
            }

            return tokens[0].IntValue;
        }

        public MathOperator GetMaxPrecedence(List<MathToken> tokens)
        {
            MathOperator maxPrecedenceOperator = null;

            foreach (var token in tokens)
            {
                if (!token.IsOperator())
                    continue;

                var op = this.operatorFactory.Create(token);
                if (maxPrecedenceOperator == null || op.Precedence >= maxPrecedenceOperator.Precedence)
                    maxPrecedenceOperator = op;
            }
            return maxPrecedenceOperator;
        }
    }
}
