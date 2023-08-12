using Basket.Host.Models.Dto;

namespace Basket.Host.Models.Requests
{
    public class DeleteBasketItemRequest
    {
        public BasketItemDto Item { get; set; } = null!;
    }
}
