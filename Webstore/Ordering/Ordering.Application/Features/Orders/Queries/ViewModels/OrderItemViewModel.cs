namespace Ordering.Application.Features.Orders.Queries.ViewModels;

public class OrderItemViewModel
{
    // Relevant information from EntityBase
    public int Id { get; set; }

    // Relevant information from OrderItem
    public string ProductName { get; set; }
    public string ProductId { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Units { get; set; }
}