using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Factories;
using Ordering.Application.Features.Orders.Queries.ViewModels;

namespace Ordering.Application.Features.Orders.Queries.GetListOfOrders;

public class GetListOfOrdersQueryHandler : IRequestHandler<GetListOfOrders.GetListOfOrdersQuery, List<OrderViewModel>>
{
    private readonly IOrderViewModelFactory _factory;
    private readonly IOrderRepository _repository;

    public GetListOfOrdersQueryHandler(IOrderRepository repository, IOrderViewModelFactory factory)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public async Task<List<OrderViewModel>> Handle(GetListOfOrders.GetListOfOrdersQuery request, CancellationToken cancellationToken)
    {
        var orderList = await _repository.GetOrdersByUsername(request.Username);
        return orderList
            .Select(order => _factory.CreateViewModel(order))
            .ToList();
    }
}