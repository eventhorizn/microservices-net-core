using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopper.AspNet.Entities;
using Shopper.AspNet.Repositories.Interfaces;

namespace Shopper.AspNet.Pages;

public class OrderModel : PageModel
{
    private readonly IOrderRepository _orderRepository;
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();

    public OrderModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Orders = await _orderRepository.GetOrdersByUserName("test");

        return Page();
    }       
}