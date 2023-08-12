using Catalog.Host.Models.Requests.Category;
using Catalog.Host.Models.Response.Category;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]

[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogcategory")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogCategoryController : ControllerBase
{
    private readonly ICatalogCategoryService _catalogCategoryService;

    public CatalogCategoryController(ICatalogCategoryService catalogCategoryService)
    {
        _catalogCategoryService = catalogCategoryService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(AddCategoryRequest request)
    {
        var result = await _catalogCategoryService.AddCategoryAsync(request.Title);
        return Ok(new AddCategoryResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteCategoryRequest request)
    {
        var result = await _catalogCategoryService.DeleteCategoryAsync(request.Id);

        if (result != null)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateCategoryRequest request)
    {
        var result = await _catalogCategoryService.UpdateCategoryAsync(request.Id, request.Title);
        return Ok(new UpdateCategoryResponse<int?>() { Id = result });
    }
}