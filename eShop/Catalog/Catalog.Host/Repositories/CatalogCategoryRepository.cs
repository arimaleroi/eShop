using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogCategoryRepository : ICatalogCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogCategoryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int?> AddCategoryAsync(string title)
    {
        var category = await _dbContext.AddAsync(new CatalogCategory { Category = title });
        await _dbContext.SaveChangesAsync();

        return category.Entity.Id;
    }

    public async Task<int?> DeleteCategoryAsync(int id)
    {
        var category = await _dbContext.CatalogCategory.FirstOrDefaultAsync(x => x.Id == id);

        if (category == null)
        {
            return null;
        }

        var result = _dbContext.Remove(category);
        _dbContext.SaveChanges();

        return result.Entity.Id;
    }

    public async Task<CatalogCategory?> GetCategoryIdAsync(int id)
    {
        var category = await _dbContext.CatalogCategory.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.SaveChanges();

        return category;
    }

    public async Task<int?> UpdateCategoryAsync(int id, string title)
    {
        var category = await _dbContext.CatalogCategory.FirstOrDefaultAsync(x => x.Id == id);

        if (category == null)
        {
            return null;
        }
        else
        {
            category.Category = title;
            _dbContext.CatalogCategory.Update(category);
            _dbContext.SaveChanges();
            return category.Id;
        }
    }
}
