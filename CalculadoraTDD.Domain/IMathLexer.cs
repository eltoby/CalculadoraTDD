namespace CalculadoraTDD.Domain
{
    using System.Collections.Generic;

    public interface IMathLexer
    {
        List<MathToken> GetTokens(string expression);
    }
}