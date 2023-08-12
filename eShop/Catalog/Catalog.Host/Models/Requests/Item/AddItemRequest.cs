namespace Catalog.Host.Models.Requests.Item;

public class AddItemRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public int CatalogCategoryId { get; set; }
}