using Microsoft.EntityFrameworkCore;
using MyWeb.Models;

namespace MyWeb
{
    public class MyWebDatabase : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Bill> Bills => Set<Bill>();

    }
}
