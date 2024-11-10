using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController: ControllerBase
{
    private readonly IBasketRepository _basketRepository;
    private readonly ILogger<BasketController> _logger;
    private readonly CouponGrpcService _couponService;


    public BasketController(IBasketRepository basketRepository, ILogger<BasketController> logger,
        CouponGrpcService couponService)
    {
        _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _couponService = couponService ?? throw new ArgumentNullException(nameof(couponService));
    }

    [HttpGet("{username}")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
    {
        var basket = await _basketRepository.GetBasket(username);
        if (basket == null)
            return NotFound();
        return Ok(basket ?? new ShoppingCart(username));
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
       
        
        foreach (var item in basket.Items)
        {
            try
            {
                var coupon = await _couponService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
            catch (RpcException e)
            {
                _logger.LogInformation("Error while retrieving coupon for item {ProductName}: {message}", item.ProductName, e.Message);
            }
        }
        
        return Ok(await _basketRepository.UpdateBasket(basket));
    }

    [HttpDelete("{username}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteBasket(string username)
    {
        
        
        await _basketRepository.DeleteBasket(username);
        return Ok();
    }
}