using Discount.Common.DTOs;
using Discount.Common.Entities;

namespace Discount.Common.Repositories;

public interface ICouponRepository
{
    Task<CouponDTO> GetDiscount(string productName);
    Task<bool> CreateDiscount(CreateCouponDTO coupon);
    Task<bool> UpdateDiscount(UpdateCouponDTO coupon);
    Task<bool> DeleteDiscount(string productName);
    Task<IEnumerable<CouponDTO>> GetRandomDiscounts(int numberOfDiscounts);
}