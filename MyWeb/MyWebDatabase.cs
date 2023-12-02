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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.ID);
            modelBuilder.Entity<Customer>().HasKey(x => x.ID);
            modelBuilder.Entity<Bill>().HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Customers)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.ID);
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.BillOwner)
                .HasPrincipalKey(e => e.ID);
        }
    }
}
