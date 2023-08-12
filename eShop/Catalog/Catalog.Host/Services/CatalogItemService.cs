using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<CatalogItemService> _logger;
    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemService> logger,
        ICatalogItemRepository catalogItemRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    public Task<int?> AddItemAsync(string title, string description, decimal price, int catalogCategoryId, string pictureFileName)
    {
        _logger.LogInformation($"Adding a new item with title: {title}");
        return ExecuteSafeAsync(() => _catalogItemRepository.AddItemAsync(title, description, price, catalogCategoryId, pictureFileName));
    }

    public Task<int?> DeleteItemAsync(int id)
    {
        _logger.LogInformation($"Deleting a new item with ID: {id}");
        return ExecuteSafeAsync(() => _catalogItemRepository.DeleteItemAsync(id));
    }

    public Task<CatalogItem?> GetItemAsync(int id)
    {
        _logger.LogInformation($"Getting a new item with ID: {id}");
        return ExecuteSafeAsync(() => _catalogItemRepository.GetItemId(id));
    }

    public Task<int?> UpdateItemAsync(int id, string title, string description, decimal price, int catalogCategoryId, string pictureFileName)
    {
        _logger.LogInformation($"Updating a new item with ID {id} and title: {title}");
        return ExecuteSafeAsync(() => _catalogItemRepository.UpdateItemAsync(id, title, description, price, catalogCategoryId, pictureFileName));
    }
}