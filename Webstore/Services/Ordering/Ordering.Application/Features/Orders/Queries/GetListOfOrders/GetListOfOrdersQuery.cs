using MediatR;
using Ordering.Application.Features.Orders.Queries.ViewModels;

namespace Ordering.Application.Features.Orders.Queries.GetListOfOrders;

public class GetListOfOrdersQuery : IRequest<List<OrderViewModel>>
{
    public GetListOfOrdersQuery(string username)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
    }

    public string Username { get; set; }
}