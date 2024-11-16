using Ordering.Domain.Aggregates;

namespace Ordering.Application.Contracts.Persistance;

public interface IOrderRepository: IAsyncRepository<Order>
{
    Task<IReadOnlyCollection<Order>> GetOrdersByUsername(string username);
}