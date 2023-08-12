using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests.Item;
using Catalog.Host.Models.Response.Item;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]

[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogitem")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(ICatalogItemService catalogItemService)
    {
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(AddItemRequest request)
    {
        var result = await _catalogItemService.AddItemAsync(request.Title, request.Description, request.Price, request.CatalogCategoryId, request.PictureFileName);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteItemRequest request)
    {
        var result = await _catalogItemService.DeleteItemAsync(request.Id);

        if (result == null)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemResponse<CatalogItem?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(DeleteItemRequest request)
    {
        var result = await _catalogItemService.GetItemAsync(request.Id);
        return Ok(new GetItemResponse<CatalogItem?>() { Item = result });
    }
}