using Shopper.AspNet.Models;

namespace Shopper.AspNet.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
}
