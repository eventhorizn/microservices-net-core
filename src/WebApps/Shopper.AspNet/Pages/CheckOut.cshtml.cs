using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopper.AspNet.Models;
using Shopper.AspNet.Services;

namespace Shopper.AspNet.Pages;

public class CheckOutModel : PageModel
{
    private readonly IBasketService _basketService;

    [BindProperty]
    public BasketCheckoutModel Order { get; set; }
    public BasketModel Cart { get; set; } = new BasketModel();

    public CheckOutModel(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var userName = "grh";
        Cart = await _basketService.GetBasket(userName);

        return Page();
    }

    public async Task<IActionResult> OnPostCheckOutAsync()
    {
        var userName = "grh";
        Cart = await _basketService.GetBasket(userName);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Order.UserName = userName;
        Order.TotalPrice = Cart.TotalPrice;

        await _basketService.CheckoutBasket(Order);

        return RedirectToPage("Confirmation", "OrderSubmitted");
    }
}