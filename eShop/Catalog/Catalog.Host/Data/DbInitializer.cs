using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogCategory.Any())
        {
            await context.CatalogCategory.AddRangeAsync(GetPreconfiguredCatalogCategories());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogCategory> GetPreconfiguredCatalogCategories()
    {
        return new List<CatalogCategory>()
        {
            new CatalogCategory() { Category = "All" },
            new CatalogCategory() { Category = "Money" },
            new CatalogCategory() { Category = "Privileges" },
            new CatalogCategory() { Category = "Cases" },
            new CatalogCategory() { Category = "Indulgence" }
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>()
        {
            new CatalogItem { CatalogCategoryId = 1, Description = "50 COINS", Title = "50 COINS", Price = 50M, PictureFileName = "6.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "100 COINS", Title = "100 COINS", Price = 100M, PictureFileName = "6.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "250 COINS", Title = "250 COINS", Price = 250M, PictureFileName = "6.png" },
            new CatalogItem { CatalogCategoryId = 1, Description = "500 COINS", Title = "500 COINS", Price = 500M, PictureFileName = "6.png" },

            new CatalogItem { CatalogCategoryId = 2, Description = "HERO", Title = "HERO", Price = 19.99M, PictureFileName = "1.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "AVENGER", Title = "AVENGER", Price = 49.99M, PictureFileName = "2.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "LEGEND", Title = "LEGEND", Price = 99.99M, PictureFileName = "3.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "LORD", Title = "LORD", Price = 169.99M, PictureFileName = "4.png" },
            new CatalogItem { CatalogCategoryId = 2, Description = "ULTRA", Title = "ULTRA", Price = 249.99M, PictureFileName = "5.png" },

            new CatalogItem { CatalogCategoryId = 3, Description = "Bronze Case", Title = "Bronze Case", Price = 30M, PictureFileName = "7.png" },
            new CatalogItem { CatalogCategoryId = 3, Description = "Silver Case", Title = "Silver Case", Price = 75M, PictureFileName = "7.png" },
            new CatalogItem { CatalogCategoryId = 3, Description = "Gold Case", Title = "Gold Case", Price = 150M, PictureFileName = "7.png" },

            new CatalogItem { CatalogCategoryId = 4, Description = "Unban account", Title = "Unban account", Price = 100M, PictureFileName = "8.png" },
            new CatalogItem { CatalogCategoryId = 4, Description = "Unmute chat", Title = "Unmute chat", Price = 25M, PictureFileName = "8.png" },
        };
    }
}