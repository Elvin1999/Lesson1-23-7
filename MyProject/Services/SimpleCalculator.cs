namespace MyProject.Services
{
    public class SimpleCalculator : ICalculator
    {
        public SimpleCalculator()
        {
            
        }
        public decimal Data { get; set; }
        public decimal Calculate(decimal value)
        {
            Data += value;
            return Data;
        }
    }
}
