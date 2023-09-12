using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;

namespace Dotnet.Infrastructure.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext dbContext): base(dbContext) { }
}