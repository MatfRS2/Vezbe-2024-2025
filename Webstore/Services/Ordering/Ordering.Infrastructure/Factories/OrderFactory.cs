using Ordering.Application.Factories;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Domain.Aggregates;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Factories;

public class OrderFactory : IOrderFactory
{
    public Order Create(CreateOrderCommand command)
    {
        var order = new Order(command.BuyerId, command.BuyerUsername, new Address(command.Street, command.City, command.State, command.Country, command.ZipCode, command.EmailAddress));
        foreach (var item in command.OrderItems)
        {
            order.AddOrderItem(item.ProductName, item.ProductId, item.PictureUrl, item.Price, item.Units);
        }
        return order;
    }
}