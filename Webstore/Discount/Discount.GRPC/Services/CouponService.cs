using AutoMapper;
using Discount.Common.Repositories;
using Grpc.Core;

namespace Discount.GRPC.Services;

public class CouponService: CouponProtoService.CouponProtoServiceBase
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CouponService> _logger;

    public CouponService(ICouponRepository couponRepository, IMapper mapper, ILogger<CouponService> logger)
    {
        _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override async Task<GetDiscountResponse> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _couponRepository.GetDiscount(request.ProductName);
        _logger.LogInformation("Get discount for product: {ProductName}", coupon.ProductName);
        return _mapper.Map<GetDiscountResponse>(coupon);
    }

    public override async Task<GetRandomDiscountsResponse> GetRandomDiscounts(GetRandomDiscountsRequest request, ServerCallContext context)
    {
        var coupons = await _couponRepository.GetRandomDiscounts(request.NumberOfDiscounts);
        
        var response = new GetRandomDiscountsResponse();
        
        throw new NotImplementedException();
    }
}