using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
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
    Task<CatalogItem?> GetItemAsync(int id);
}