namespace MyWeb.Services
{
    public class CalculationService
    {
        private readonly CalculationDelta delta;
        public CalculationService(CalculationDelta delta)
        {
            this.delta = delta;
        }
        public double Sum(int a, int b, int c)
        {
            return a + b + delta.Delta(a, b, c);
        }
        public double Multiplication(int a, int b, int c)
        {
            return a * b * c;
        }
    }
}
