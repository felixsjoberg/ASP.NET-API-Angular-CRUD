using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Account> Accounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>().HasData(
            new Owner
            {
                Id = 1,
                Name = "John",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Main St",

            },
            new Owner
            {
                Id = 2,
                Name = "Jane",
                DateOfBirth = new DateTime(1985, 1, 1),
                Address = "456 Main St"
            }
        );
        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Id = 1,
                DateCreated = new DateTime(2022, 1, 1),
                AccountType = "Checking",
                OwnerId = 1
            },
            new Account
            {
                Id = 2,
                DateCreated = new DateTime(2022, 1, 2),
                AccountType = "Savings",
                OwnerId = 2
            });
    }
}