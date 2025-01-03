namespace Basket.API.Entities;

public class ShoppingCart
{
    public ShoppingCart(string username = null)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
    }

    public string Username { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(i => i.Price*i.Quantity);
}
