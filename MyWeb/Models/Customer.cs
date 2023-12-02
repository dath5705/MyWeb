using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Customer
    {
        private readonly ILazyLoader? lazyLoader;
        public Customer() { }
        public Customer(ILazyLoader loader)
        {
            lazyLoader = loader;
        }
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string? Number { get; set; } = string.Empty;
        public int? UserId { get; set; } = 0;
        public bool? Sex { get; set; } = true;
        public string? Address { get; set; } = string.Empty;
        public int? TotalMoney { get; set; } = 0;
        public User? user;
        public User? User { get => lazyLoader?.Load(this, ref user); set => user = value; }
        public ICollection<Bill>? bills;
        public ICollection<Bill>? Bills { get => lazyLoader?.Load(this, ref bills); set => bills = value; }

    }
}
