using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;

namespace Dotnet.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}