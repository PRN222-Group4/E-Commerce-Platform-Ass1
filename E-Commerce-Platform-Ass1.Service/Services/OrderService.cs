using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Platform_Ass1.Data.Database.Entities;
using E_Commerce_Platform_Ass1.Data.Repositories.Interfaces;
using E_Commerce_Platform_Ass1.Service.Services.IServices;

namespace E_Commerce_Platform_Ass1.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrderHistoryAsync(Guid userId)
        {
            return await _orderRepository.GetByUserIdAsync(userId);
        }

        public async Task<Order?> GetOrderItemAsync(Guid orderId)
        {
            return await _orderRepository.GetByIdWithDetailsAsync(orderId);
        }
    }
}
