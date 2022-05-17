using Shopper.AspNet.Entities;

namespace Shopper.AspNet.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order> CheckOut(Order order);
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}
