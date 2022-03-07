using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistence;

internal interface IOrderRepository : IAsyncRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}
