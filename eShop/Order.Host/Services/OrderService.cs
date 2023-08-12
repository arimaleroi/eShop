using Basket.Host.Services.Interfaces;
using Order.Host.Data;
using Order.Host.Models;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketService _basketService;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IUserService userService, ApplicationDbContext dbContext, IOrderRepository orderRepository, IBasketService basketService, ILogger<OrderService> logger)
        {
            _userService = userService;
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _basketService = basketService;
            _logger = logger;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            return await _orderRepository.GetOrderAsync(orderId);
        }

        public async Task<OrderDto> AddOrderAsync(OrderDto order)
        {
            var addOrder = await _orderRepository.AddOrderAsync(order);

            var userInfo = await _userService.GetUserInfoAsync(order.UserInfo.UserId);

            addOrder.UserInfo = userInfo;

            await _dbContext.Orders.AddAsync(addOrder);
            await _dbContext.SaveChangesAsync();

            return addOrder;
        }
    }
}
