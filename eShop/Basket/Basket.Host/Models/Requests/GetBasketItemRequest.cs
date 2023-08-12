using Basket.Host.Models.Dto;

namespace Basket.Host.Models.Requests;

public class GetBasketItemRequest
{
    public BasketItemDto Data { get; set; } = null!;
}