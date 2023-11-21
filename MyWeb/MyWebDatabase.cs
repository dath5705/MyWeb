using Microsoft.EntityFrameworkCore;
using MyWeb.Models;

namespace MyWeb
{
    public class MyWebDatabase : DbContext
    {
        public MyWebDatabase(
           DbContextOptions<MyWebDatabase> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Bill> Bills => Set<Bill>();

    }
}
