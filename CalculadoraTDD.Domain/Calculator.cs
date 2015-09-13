namespace CalculadoraTDD.Domain
{
    public class Calculator : ICalculator
    {
        public int Add(int sumando1, int sumando2)
        {
            return sumando1 + sumando2;
        }

        public int Substract(int minuend, int sustrahend)
        {
            return minuend - sustrahend;
        }

        public int Multiply(int n1, int n2)
        {
            return n1*n2;
        }

        public int Divide(int n1, int n2)
        {
            return n1/n2;
        }
    }
}
