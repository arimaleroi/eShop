namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public CatalogCategoryDto Category { get; set; } = null!;
}
