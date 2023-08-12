using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogCategoryService : BaseDataService<ApplicationDbContext>, ICatalogCategoryService
{
    private readonly ICatalogCategoryRepository _catalogCategoryRepository;
    private readonly ILogger<CatalogCategoryService> _logger;
    public CatalogCategoryService(
           IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
           ILogger<CatalogCategoryService> logger,
           ICatalogCategoryRepository catalogCategoryRepository)
           : base(dbContextWrapper, logger)
    {
        _catalogCategoryRepository = catalogCategoryRepository;
        _logger = logger;
    }

    public Task<int?> AddCategoryAsync(string title)
    {
        _logger.LogInformation($"Adding a new category with title: {title}");
        return ExecuteSafeAsync(() => _catalogCategoryRepository.AddCategoryAsync(title));
    }

    public Task<int?> DeleteCategoryAsync(int id)
    {
        _logger.LogInformation($"Deleting a new category with ID: {id}");
        return ExecuteSafeAsync(() => _catalogCategoryRepository.DeleteCategoryAsync(id));
    }

    public Task<int?> UpdateCategoryAsync(int id, string title)
    {
        _logger.LogInformation($"Updating a new category with ID {id} and title: {title}");
        return ExecuteSafeAsync(() => _catalogCategoryRepository.UpdateCategoryAsync(id, title));
    }

    public Task<CatalogCategory?> GetCategoryIdAsync(int id)
    {
        _logger.LogInformation($"Getting a new category with ID: {id}");
        return ExecuteSafeAsync(() => _catalogCategoryRepository.GetCategoryIdAsync(id));
    }
}
