namespace MVC.Models.Requests.Item
{
    public class AddItemRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public int CatalogCategoryId { get; set; }
    }
}
