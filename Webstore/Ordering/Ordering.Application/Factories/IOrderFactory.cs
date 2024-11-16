using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Domain.Aggregates;

namespace Ordering.Application.Factories;

public interface IOrderFactory
{
    Order Create(CreateOrderCommand command);
}