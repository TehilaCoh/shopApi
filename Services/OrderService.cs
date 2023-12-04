using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrederRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _OrederRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Order> CreateNewOrder(Order order)
        {
            double data_order_sum = 0;
            var o = order.OrderItems;
           
            return await _OrederRepository.Post(order);
        }
    }
}
