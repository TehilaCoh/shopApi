using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AdoNet1Context _DbContext;
        public OrderRepository(AdoNet1Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Order> Post(Order order)
        {
            await _DbContext.AddAsync(order);
            await _DbContext.SaveChangesAsync();

            return order;
        }
    }
}
