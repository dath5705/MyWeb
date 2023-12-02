using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Bill
    {
        private readonly ILazyLoader? lazyLoader;
        public Bill() { }
        public Bill(ILazyLoader loader)
        {
            lazyLoader = loader;
        }
        public int Id { get; set; } = 0;
        public int BillNumber { get; set; } = 0;
        public DateTime Date {  get; set; }  = DateTime.Now;
        public int BillOwner { get; set; } = 0;
        public Customer? owner;
        public Customer? Owner {get => lazyLoader.Load(this, ref owner); set => owner = value;}


    }
}
