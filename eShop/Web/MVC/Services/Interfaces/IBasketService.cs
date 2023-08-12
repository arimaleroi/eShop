using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task AddBasket(CatalogItem catalogItem);
        Task DeleteBasket(CatalogItem catalogItem);
        Task<Basket> GetBasket();
    }
}
