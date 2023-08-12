using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> GetCatalogItems(int page, int take, int? category);
    Task<IEnumerable<SelectListItem>> GetCategories();
    Task<CatalogItem> GetItemId(int id);
}
