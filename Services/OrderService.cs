using Entities;
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
        public OrderService(IOrderRepository orderRepository)
        {
            _OrederRepository = orderRepository;
        }

        public async Task<Order> Post(Order order)
        {

            return await _OrederRepository.Post(order);
        }
    }
}
