﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopper.AspNet.Models;
using Shopper.AspNet.Services;

namespace Shopper.AspNet.Pages;

public class ProductModel : PageModel
{
    private readonly ICatalogService _catalogService;
    private readonly IBasketService _basketService;

    public ProductModel(ICatalogService catalogService, IBasketService basketService)
    {
        _catalogService = catalogService;
        _basketService = basketService;
    }

    public IEnumerable<string> CategoryList { get; set; } = new List<string>();
    public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();


    [BindProperty(SupportsGet = true)]
    public string SelectedCategory { get; set; }

    public async Task<IActionResult> OnGetAsync(string categoryName)
    {
        var productList = await _catalogService.GetCatalog();
        CategoryList = productList.Select(p => p.Category).Distinct();

        if (!string.IsNullOrWhiteSpace(categoryName))
        {
            ProductList = productList.Where(p => p.Category == categoryName);
            SelectedCategory = categoryName;
        }
        else
        {
            ProductList = productList;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(string productId)
    {
        var product = await _catalogService.GetCatalog(productId);

        var userName = "swn";
        var basket = await _basketService.GetBasket(userName);

        basket.Items.Add(new BasketItemModel
        {
            ProductId = productId,
            ProductName = product.Name,
            Price = product.Price,
            Quantity = 1,
            Color = "Black"
        });

        await _basketService.UpdateBasket(basket);

        return RedirectToPage("Cart");
    }
}