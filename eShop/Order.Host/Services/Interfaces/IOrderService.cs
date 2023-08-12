using Order.Host.Models;

namespace Order.Host.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderAsync(int userId);
        Task<OrderDto> AddOrderAsync(OrderDto order);
    }
}
