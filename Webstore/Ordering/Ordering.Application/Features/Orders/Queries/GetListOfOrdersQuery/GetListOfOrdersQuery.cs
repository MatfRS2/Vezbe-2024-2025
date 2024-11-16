using MediatR;
using Ordering.Application.Features.Orders.Queries.ViewModels;

namespace Ordering.Application.Features.Orders.Queries.GetListOfOrdersQuery;

public class GetListOfOrdersQuery: IRequest<List<OrderViewModel>>
{
    public string Username { get; set; }

    public GetListOfOrdersQuery(string username)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
    }
}