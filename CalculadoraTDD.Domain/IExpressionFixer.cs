namespace CalculadoraTDD.Domain
{
    using System.Collections.Generic;

    public interface IExpressionFixer
    {
        IList<string> FixExpressions(IList<string> expressions);
    }
}