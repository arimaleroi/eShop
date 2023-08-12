using System.Collections.Generic;
using Basket.Host.Models.Dto;
using Basket.Host.Services;
using Basket.Host.Services.Interfaces;

namespace Basket.UnitTests.Services
{
    public class BasketServiceTest
    {
        private readonly BasketService _basketService;
        private readonly Mock<ICacheService> _cacheService;
        private readonly Mock<ILogger<BasketService>> _logger;

        public BasketServiceTest()
        {
            _cacheService = new Mock<ICacheService>();
            _logger = new Mock<ILogger<BasketService>>();
            _basketService = new BasketService(_cacheService.Object, _logger.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            var testUserId = "userId";
            int testResult = 1;
            BasketItemDto catalogItemDto = new BasketItemDto();

            _cacheService.Setup(x => x.GetAsync<BasketDataDto>(testUserId)).ReturnsAsync(new BasketDataDto { BasketData = new List<BasketItemDto>() });
            _cacheService.Setup(x => x.AddOrUpdateAsync(testUserId, It.IsAny<BasketDataDto>())).Returns(Task.CompletedTask);

            var result = await _basketService.AddAsync(testUserId, catalogItemDto);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            var testUserId = "userId";
            BasketItemDto catalogItemDto = new BasketItemDto();

            _cacheService.Setup(x => x.GetAsync<BasketDataDto>(testUserId)).ReturnsAsync(new BasketDataDto { BasketData = new List<BasketItemDto>() });

            _cacheService.Setup(x => x.AddOrUpdateAsync(testUserId, It.IsAny<BasketDataDto>()))
            .ThrowsAsync(new Exception("Cache service exception"));

            await Assert.ThrowsAsync<Exception>(() => _basketService.AddAsync(testUserId, catalogItemDto));
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            var testUserId = "userId";
            int testResult = 0;
            var testBasketItem = new BasketItemDto { Id = 1 };

            var data = new BasketDataDto { BasketData = new List<BasketItemDto> { testBasketItem } };

            _cacheService.Setup(x => x.GetAsync<BasketDataDto>(testUserId)).ReturnsAsync(data);
            _cacheService.Setup(x => x.AddOrUpdateAsync(testUserId, It.IsAny<BasketDataDto>())).Returns(Task.CompletedTask);

            var result = await _basketService.DeleteAsync(testUserId, data.BasketData[0]);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteAsync_Failed()
        {
            var testUserId = "userId";
            var testBasketItem = new BasketItemDto { Id = 1 };

            _cacheService.Setup(x => x.GetAsync<BasketDataDto?>(testUserId)).ReturnsAsync((BasketDataDto?)null);

            var result = await _basketService.DeleteAsync(testUserId, testBasketItem);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            var testUserId = "userId";
            var data = new BasketDataDto();

            _cacheService.Setup(x => x.GetAsync<BasketDataDto>(testUserId))
                .ReturnsAsync(data);

            var result = await _basketService.GetAsync(testUserId);

            result.Should().Be(data);
        }

        [Fact]
        public async Task GetAsync_Failed()
        {
            var testUserId = "userId";

            _cacheService.Setup(x => x.GetAsync<BasketDataDto?>(testUserId))
                .ReturnsAsync((BasketDataDto?)null);

            var result = await _basketService.GetAsync(testUserId);

            result.Should().BeNull();
        }
    }
}