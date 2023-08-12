using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Dtos;
using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Catalog> GetCatalogItems(int page, int take, int? category)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (category.HasValue)
        {
            filters.Add(CatalogTypeFilter.Category, category.Value);
        }
        
        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/items",
           HttpMethod.Post, 
           new PaginatedItemsRequest<CatalogTypeFilter>()
            {
                PageIndex = page,
                PageSize = take,
                Filters = filters
            });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetCategories()
    {
        await Task.Delay(300);
        var list = new List<SelectListItem>
        {
            new SelectListItem()
            {
                Text = "All"
            },
            new SelectListItem()
            {
                Value = "1",
                Text = "Money"
            },
            new SelectListItem()
            {
                Value = "2",
                Text = "Privileges"
            },
            new SelectListItem()
            {
                Value = "3",
                Text = "Cases"
            },
            new SelectListItem()
            {
                Value = "4",
                Text = "Indulgence"
            }
        };
        var result = await _httpClient.SendAsync<object, object>($"{_settings.Value.CatalogUrl}/getcategories",
            HttpMethod.Post, new {} );
        
        return list;
    }

    public async Task<CatalogItem> GetItemId(int id)
    {
        var result = await _httpClient.SendAsync<CatalogItem, GetRequest>($"{_settings.Value.CatalogUrl}/GetItemId",
           HttpMethod.Post,
           new GetRequest
           {
               Id = id
           });

        return result;
    }
}
