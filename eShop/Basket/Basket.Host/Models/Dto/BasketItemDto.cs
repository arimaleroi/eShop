namespace Basket.Host.Models.Dto
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureFileName { get; set; } = null!;
    }
}
