using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? categoryFilter)
    {
        IQueryable<CatalogItem> query = _dbContext.CatalogItems;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query.OrderBy(c => c.Title)
           .Include(i => i.CatalogCategory)
           .Skip(pageSize * pageIndex)
           .Take(pageSize)
           .ToListAsync();
        _dbContext.SaveChanges();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> AddItemAsync(string title, string description, decimal price, int catalogCategoryId, string pictureFileName)
    {
        var result = await _dbContext.CatalogItems.AddAsync(new CatalogItem
        {
            Title = title,
            Description = description,
            Price = price,
            PictureFileName = pictureFileName,
            CatalogCategoryId = catalogCategoryId
        });
        _dbContext.SaveChanges();

        return result.Entity.Id;
    }

    public async Task<int?> DeleteItemAsync(int id)
    {
        var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
        {
            return null;
        }

        var result = _dbContext.Remove(item);
        _dbContext.SaveChanges();

        return result.Entity.Id;
    }

    public async Task<CatalogItem?> GetItemId(int id)
    {
        var result = await _dbContext.CatalogItems
                .Include(x => x.CatalogCategory)
                .FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.SaveChanges();

        return result;
    }

    public async Task<int?> UpdateItemAsync(int id, string title, string description, decimal price, int catalogCategoryId, string pictureFileName)
    {
        var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);

        if (item != null)
        {
            item.Title = title;
            item.Description = description;
            item.Price = price;
            item.CatalogCategoryId = catalogCategoryId;
            item.PictureFileName = pictureFileName;
            _dbContext.SaveChanges();
            return item.Id;
        }
        else
        {
            return null;
        }
    }
}