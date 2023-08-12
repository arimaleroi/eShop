using Basket.Host.Models;
using Basket.Host.Models.Requests;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketBffController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddBasketItemRequest), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddAsync(AddBasketItemRequest data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.AddAsync(basketId!, data.Item);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetBasketItemRequest), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.GetAsync(basketId!);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteBasketItemRequest), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteAsync(DeleteBasketItemRequest data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.DeleteAsync(basketId!, data.Item);

        return Ok();
    }
}