namespace MVC.ViewModels
{
    public record Basket
    {
        public List<CatalogItem> Data { get; set; }
        public string UserId { get; set; }
    }
}
