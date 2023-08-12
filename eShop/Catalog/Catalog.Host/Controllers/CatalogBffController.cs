using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.Item;
using Catalog.Host.Models.Response;
using Catalog.Host.Models.Response.Item;
using Catalog.Host.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]

[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ICatalogService _catalogService;
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogCategoryService _catalogCategoryService;

    public CatalogBffController(
        ICatalogService catalogService,
        ICatalogItemService catalogItemService,
        ICatalogCategoryService catalogCategoryService)
    {
        _catalogService = catalogService;
        _catalogItemService = catalogItemService;
        _catalogCategoryService = catalogCategoryService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItemId(GetItemRequest request)
    {
        var result = await _catalogItemService.GetItemAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemResponse<CatalogCategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryId(GetCategoryRequest request)
    {
        var result = await _catalogCategoryService.GetCategoryIdAsync(request.Id);
        return Ok(result);
    }
}