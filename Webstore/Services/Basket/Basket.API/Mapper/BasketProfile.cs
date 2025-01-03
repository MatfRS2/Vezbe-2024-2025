using AutoMapper;

namespace Basket.API.Mapper;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<Entities.BasketCheckout, EventBus.Messages.Events.BasketCheckoutEvent>().ReverseMap();
        CreateMap<Entities.BasketItem, EventBus.Messages.Events.BasketItem>().ReverseMap();
    }
}