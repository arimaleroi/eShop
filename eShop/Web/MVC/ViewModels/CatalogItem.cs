namespace MVC.ViewModels;

public record CatalogItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;

}