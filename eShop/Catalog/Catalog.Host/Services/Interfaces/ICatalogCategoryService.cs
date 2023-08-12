using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogCategoryService
{
    Task<int?> AddCategoryAsync(string title);
    Task<int?> UpdateCategoryAsync(int id, string title);
    Task<int?> DeleteCategoryAsync(int id);
    Task<CatalogCategory?> GetCategoryIdAsync(int id);
}
