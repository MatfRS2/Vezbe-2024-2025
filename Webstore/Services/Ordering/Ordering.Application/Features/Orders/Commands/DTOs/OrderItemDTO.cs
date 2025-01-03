namespace Ordering.Application.Features.Orders.Commands.DTOs;

public class OrderItemDTO
{
    // Relevant information from OrderItem
    public string ProductName { get; set; }
    public string ProductId { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Units { get; set; }
}