using Microsoft.EntityFrameworkCore;
using Shopper.AspNet.Data;
using Shopper.AspNet.Repositories;
using Shopper.AspNet.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// use in-memory database
//services.AddDbContext<AspnetRunContext>(c =>
//    c.UseInMemoryDatabase("AspnetRunConnection"));

// add database dependecy
builder.Services.AddDbContext<Context>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("ShopperAspNetConnection")));

// add repository dependecy
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
