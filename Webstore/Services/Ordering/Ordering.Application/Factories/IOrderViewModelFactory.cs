using Ordering.Application.Features.Orders.Queries.ViewModels;
using Ordering.Domain.Aggregates;

namespace Ordering.Application.Factories;

public interface IOrderViewModelFactory
{
    OrderViewModel CreateViewModel(Order order);
}