using Basket.Host.Models.Dto;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task<int?> AddAsync(string userId, BasketItemDto basketItemDto);
    Task<int?> DeleteAsync(string userId, BasketItemDto basketItemDto);
    Task<BasketDataDto> GetAsync(string userId);
}