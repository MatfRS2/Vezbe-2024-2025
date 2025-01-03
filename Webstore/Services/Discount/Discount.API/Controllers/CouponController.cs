using AutoMapper;
using Discount.Common.DTOs;
using Discount.Common.Entities;
using Discount.Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CouponController: ControllerBase
{
    private readonly ICouponRepository _couponRepository;
    
    public CouponController(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
    }

    [HttpGet("{productName}")]
    [ProducesResponseType(typeof(Coupon), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CouponDTO>> GetDiscount(string productName)
    {
        var coupon = await _couponRepository.GetDiscount(productName);
        if (coupon == null)
            return NotFound();
        return Ok(coupon);
    }
}