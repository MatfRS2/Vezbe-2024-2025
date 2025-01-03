using AutoMapper;
using Dapper;
using Discount.Common.Data;
using Discount.Common.DTOs;
using Discount.Common.Entities;

namespace Discount.Common.Repositories;

public class CouponRepository: ICouponRepository
{
    private readonly ICouponContext _context;
    private readonly IMapper _mapper;

    public CouponRepository(ICouponContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CouponDTO> GetDiscount(string productName)
    {
        using var connection = _context.GetConnection();
        const string sql = "SELECT * FROM Coupon WHERE ProductName = @ProductName";
        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(sql, new {ProductName = productName});

        return _mapper.Map<CouponDTO>(coupon);
    }

    public async Task<bool> CreateDiscount(CreateCouponDTO coupon)
    {
        using var connection = _context.GetConnection();
        int affected = await connection.ExecuteAsync(
            "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
        return affected > 0;
    }

    public async Task<bool> UpdateDiscount(UpdateCouponDTO coupon)
    {
        using var connection = _context.GetConnection();
        int affected = await connection.ExecuteAsync(
            "UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE ID=@Id" ,
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id =coupon.Id });
        return affected > 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CouponDTO>> GetRandomDiscounts(int numberOfDiscounts)
    {
        using var connection = _context.GetConnection();
        var coupons = await connection.QueryAsync<Coupon>("SELECT * FROM Coupon");
        if(coupons.Count() < numberOfDiscounts)
            return _mapper.Map<IEnumerable<CouponDTO>>(coupons);
        
        var random = new Random();
        return _mapper.Map<IEnumerable<CouponDTO>>(
            coupons
                .Select(coupon => new { rang=random.Next(), item=coupon })
                .OrderBy(obj => obj.rang)
                .Select(obj => obj.item)
                .Take(numberOfDiscounts)
            );
    }
}