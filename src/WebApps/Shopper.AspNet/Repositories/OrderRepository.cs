using Microsoft.EntityFrameworkCore;
using Shopper.AspNet.Data;
using Shopper.AspNet.Entities;
using Shopper.AspNet.Repositories.Interfaces;

namespace Shopper.AspNet.Repositories;

public class OrderRepository : IOrderRepository
{
    protected readonly Context _dbContext;

    public OrderRepository(Context dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Order> CheckOut(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        var orderList = await _dbContext.Orders
                        .Where(o => o.UserName == userName)
                        .ToListAsync();

        return orderList;
    }
}