using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopper.AspNet.Models;
using Shopper.AspNet.Services;

namespace Shopper.AspNet.Pages;

public class OrderModel : PageModel
{
    private readonly IOrderService _orderService;

    public IEnumerable<OrderResponseModel> Orders { get; set; } = new List<OrderResponseModel>();

    public OrderModel(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Orders = await _orderService.GetOrdersByUserName("grh");

        return Page();
    }
}