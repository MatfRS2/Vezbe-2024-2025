namespace Basket.API.Entities;

public class ShoppingCart
{
    public ShoppingCart(string username = null)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
    }

    public string Username { get; set; }
    public List<ShoppingCartItem> Items = new List<ShoppingCartItem>();
    public int TotalPrice;
}
