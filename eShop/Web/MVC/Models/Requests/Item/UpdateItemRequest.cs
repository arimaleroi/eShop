namespace MVC.Models.Requests.Item
{
    public class UpdateItemRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }

    }
}
