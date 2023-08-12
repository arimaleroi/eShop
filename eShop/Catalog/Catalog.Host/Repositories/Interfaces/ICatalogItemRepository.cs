using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? categoryFilter);
    Task<int?> AddItemAsync(
         string title,
         string description,
         decimal price,
         int catalogCategoryId,
         string pictureFileName);
    Task<int?> DeleteItemAsync(int id);
    Task<int?> UpdateItemAsync(
        int id,
        string title,
        string description,
        decimal price,
        int catalogCategoryId,
        string pictureFileName);
    Task<CatalogItem?> GetItemId(int id);
}