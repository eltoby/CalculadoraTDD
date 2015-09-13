namespace CalculadoraTDD.Domain
{
    public interface ICalculator
    {
        int Add(int sumando1, int sumando2);

        int Substract(int minuend, int sustrahend);
        
        int Multiply(int n1, int n2);
        
        int Divide(int n1, int n2);
    }
}
