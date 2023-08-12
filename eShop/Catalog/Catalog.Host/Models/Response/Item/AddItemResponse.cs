namespace Catalog.Host.Models.Response.Item;

public class AddItemResponse<T>
{
    public T Id { get; set; } = default!;
}