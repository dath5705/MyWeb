namespace MyWeb.Commands
{
    public class CalculateCommand
    {
        public int FirstNumber { get; set; } = 0;
        public int SecondNumber { get; set; } = 0;
        public int ThirdNumber { get; set; } = 0;
        public double Delta 
        {
            get
            {
                double delta = (SecondNumber * SecondNumber) - 4 * FirstNumber * ThirdNumber;
                return delta;
            }
            set 
            { 

            }
        }
        
    }
}
