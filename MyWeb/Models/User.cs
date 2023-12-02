using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class User
    {
        // EFCore Lazyloader
        private readonly ILazyLoader? lazyLoader ;
        public User() { }
        public User(ILazyLoader loader) 
        {
            lazyLoader = loader; 
        }
        public int ID { get; set; } = 0;
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public int? Revenue { get; set; } = 0;
        private ICollection<Customer>? customers;
        public ICollection<Customer>? Customers { get => lazyLoader?.Load(this, ref customers); set => customers = value; }
    }
}