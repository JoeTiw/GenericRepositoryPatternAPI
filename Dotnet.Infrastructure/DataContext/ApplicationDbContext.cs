using Dotnet.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Infrastructure.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customer { get; set; }

}