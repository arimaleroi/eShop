using Order.Host.Models;

namespace Order.Host.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderDto> GetOrderAsync(int orderId);
        Task<OrderDto> AddOrderAsync(OrderDto order);
        Task<OrderDto> UpdateOrderAsync(OrderDto order);
    }
}
