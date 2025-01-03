using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Aggregates;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyCollection<Order>> GetOrdersByUsername(string username)
    {
        return await _dbContext.Orders
            .Where(o => o.BuyerUsername == username)
            .Include(o => o.OrderItems)
            .ToListAsync();
    }
}