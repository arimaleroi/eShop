namespace Catalog.Host.Models.Response.Item;

public class GetItemResponse<T>
{
    public T Item { get; set; } = default!;
}
