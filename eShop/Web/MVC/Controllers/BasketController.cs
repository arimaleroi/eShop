using Microsoft.AspNetCore.Mvc;
using MVC.Services.Interfaces;

namespace MVC.Controllers
{
    public class BasketController : Controller
    {
        private IBasketService _basketService;
        private readonly ICatalogService _catalogService;

        public BasketController(IBasketService basketService, ICatalogService catalogService)
        {
            _basketService = basketService;
            _catalogService = catalogService;
        }
        public async Task<IActionResult> Add(int catalogItemId)
        {
            var catalogItem = await _catalogService.GetItemId(catalogItemId);
            await _basketService.AddBasket(catalogItem);

            return Redirect("~/");
        }

        public async Task<IActionResult> Delete(int catalogItemId)
        {
            var catalogItem = await _catalogService.GetItemId(catalogItemId);
            await _basketService.DeleteBasket(catalogItem);
            

            return Redirect("~/Basket/Get");
        }

        public async Task<IActionResult> Get()
        {
            var model = await _basketService.GetBasket();

            return View(model);
        }


    }
}
