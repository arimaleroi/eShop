using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogCategoryRepository
{
    Task<int?> AddCategoryAsync(string title);
    Task<int?> DeleteCategoryAsync(int id);
    Task<int?> UpdateCategoryAsync(int id, string title);
    Task<CatalogCategory?> GetCategoryIdAsync(int id);
}
