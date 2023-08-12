namespace Catalog.Host.Models.Requests.Category;

public class UpdateCategoryRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}
