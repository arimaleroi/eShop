using Basket.Host.Models.Dto;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;
    private readonly ILogger<BasketService> _logger;
    public BasketService(ICacheService cacheService, ILogger<BasketService> logger)
    {
        _cacheService = cacheService;
        _logger = logger;
    }

    public async Task<BasketDataDto> GetAsync(string userId)
    {
        _logger.LogInformation($"The user: {userId} received data from the basket");
        return await _cacheService.GetAsync<BasketDataDto>(userId);
    }

    public async Task<int?> AddAsync(string userId, BasketItemDto catalogItemDto)
    {
        var data = await _cacheService.GetAsync<BasketDataDto>(userId);

        if (data == null)
        {
            data = new BasketDataDto { BasketData = new List<BasketItemDto>() };
        }

        data.BasketData.Add(catalogItemDto);

        await _cacheService.AddOrUpdateAsync(userId, data);

        _logger.LogInformation($"The user: {userId} added item to basket");
        return data.BasketData.Count;
    }

    public async Task<int?> DeleteAsync(string userId, BasketItemDto basketItemDto)
    {
        var data = await _cacheService.GetAsync<BasketDataDto>(userId);

        if (data != null)
        {
            var index = data.BasketData.FindIndex(item => item.Id == basketItemDto.Id);
            if (index >= 0)
            {
                data.BasketData.RemoveAt(index);
            }

            await _cacheService.AddOrUpdateAsync(userId, data);
        }

        _logger.LogInformation($"The user: {userId} deleted item from the basket");
        return data?.BasketData.Count;
    }
}