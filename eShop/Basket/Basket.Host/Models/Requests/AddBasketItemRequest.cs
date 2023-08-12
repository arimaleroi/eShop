using Basket.Host.Models.Dto;

namespace Basket.Host.Models.Requests;

public class AddBasketItemRequest
{
    public BasketItemDto Item { get; set; } = null!;
}