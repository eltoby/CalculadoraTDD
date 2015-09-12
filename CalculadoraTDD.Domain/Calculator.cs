namespace CalculadoraTDD.Domain
{
    using System;

    public class Calculator : ICalculator
    {
        public int Add(int sumando1, int sumando2)
        {
            var result = sumando1 + sumando2;
            return result;
        }

        public int Substract(int minuend, int sustrahend)
        {
            var result = minuend - sustrahend;
            return result;
        }
    }
}
