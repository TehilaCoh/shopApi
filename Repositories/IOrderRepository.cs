using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> Post(Order order);
        Task<double> getPrice(OrderItem order);
    }
} 