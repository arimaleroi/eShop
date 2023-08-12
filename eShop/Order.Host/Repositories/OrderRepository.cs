using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Order.Host.Data;
using Order.Host.Models;
using Order.Host.Repositories.Interfaces;

namespace Order.Host.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<OrderRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public Task<OrderDto> AddOrderAsync(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> UpdateOrderAsync(OrderDto order)
        {
            throw new NotImplementedException();
        }
    }
}
