using Infrastructure.Services.Interfaces;
using MVC.Models;
using MVC.Models.Requests;
using MVC.Models.Requests.Basket;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
    public class BasketService : IBasketService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<CatalogService> _logger;
        public BasketService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            _logger = logger;
        }

        public async Task AddBasket(CatalogItem catalogItem)
        {
            var result = await _httpClient.SendAsync<object, AddBasketRequest>($"{_settings.Value.BasketUrl}/Add",
            HttpMethod.Post,
            new AddBasketRequest
            {
                Item = catalogItem
            });
        }

        public async Task DeleteBasket(CatalogItem catalogItem)
        {
           var result = await _httpClient.SendAsync<object, DeleteBasketRequest>($"{_settings.Value.BasketUrl}/Delete",
           HttpMethod.Post,
           new DeleteBasketRequest
           {
               Item = catalogItem
           });
        }

        public async Task<Basket> GetBasket()
        {
            var result = await _httpClient.SendAsync<BasketResponse, object>(
                $"{_settings.Value.BasketUrl}/Get",
                HttpMethod.Post,
                null);

            _logger.LogInformation($"result: {result}");

            var basketData = new Basket
            {
                Data = new List<CatalogItem>()
            };

            if (result is null)
            {
                return basketData;
            }

            foreach (var item in result.BasketData)
            {
                basketData.Data.Add(item);
            }

            return basketData;
        }
    }
}
