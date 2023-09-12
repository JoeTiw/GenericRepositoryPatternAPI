using Dotnet.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Infrastructure.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customer { get; set; }

    public DbSet<Supplier> Supplier { get; set; }

    public DbSet<Order> Order { get; set; }
    
    public DbSet<OrderItem> OrderItem { get; set; }

    public DbSet<Product> Product { get; set; }

    public DbSet<UserRegister> UserRegister { get; set; }

    public DbSet<UserLogin> UserLogin { get; set; }

}