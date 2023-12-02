namespace MyWeb.Commands
{
    public class CustomerInput
    {
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public int IDUser { get; set; } = 0;
        public bool? Sex { get; set; } = true;
        public string? Address { get; set; } =string.Empty;
        public int? TotalMoney { get; set; } = 0;
    }
}
