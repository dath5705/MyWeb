using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; } = 0;
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
    }
}
