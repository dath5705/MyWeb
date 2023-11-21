using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string? Number { get; set; } = string.Empty;
        public int? IDUser { get; set; } = 0;
        public bool? Sex { get; set; } = true;
        public string? Address { get; set; } = string.Empty;
    }
}
