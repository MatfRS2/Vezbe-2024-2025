namespace Basket.API.Entities;

public class BasketItem
{
    public string ProductName { get; set; }
    public string ProductId { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Units { get; set; }
}