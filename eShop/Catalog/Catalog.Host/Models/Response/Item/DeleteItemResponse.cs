namespace Catalog.Host.Models.Response.Item;

public class DeleteItemResponse<T>
{
    public T Id { get; set; } = default!;
}
