namespace CalculadoraTDD.Domain
{
    public class MathToken
    {

        public MathToken(string token, int index)
        {
            this.Token = token;
            this.Index = index;
        }

        public string Token { get; set; }

        public int IntValue
        {
            get
            {
                return int.Parse(this.Token);
            }
        }

        public int Index { get; set; }

        public bool IsOperator()
        {
            const string operators = "+-*/";
            return operators.Contains(this.Token);
        }
    }
}