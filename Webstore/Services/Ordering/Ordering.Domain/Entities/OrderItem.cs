using Ordering.Domain.Common;
using Ordering.Domain.Exceptions;

namespace Ordering.Domain.Entities;

public class OrderItem: EntityBase
{
    public string ProductName { get; set; }
    public string ProductId { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Units { get; private set; } = 0;
    
    public OrderItem(string productName, string productId, string pictureUrl, decimal price, int units)
    {
        ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
        ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
        PictureUrl = pictureUrl ?? throw new ArgumentNullException(nameof(pictureUrl));
        Price = price;
        AddUnits(units);
    }

    public void AddUnits(int units)
    {
        var newUnits = Units + units;
        if (newUnits <= 0)
        {
            throw new OrderingDomainException("Invalid number of new units for order item"); 
        }

        Units = newUnits;
    }

    public decimal TotalPrice()
    {
        return Units * Price;
    }
}