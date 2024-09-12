using BurgerShop.DataBase;
using BurgerShop.DataBase.EFImplementations;
using BurgerShop.DataBase.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Service;
using BurgerShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("BurgerAppConnectionString");

builder.Services.AddDbContext<BurgerShopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IRepository<Burger>, EFBurgerRepository>();
builder.Services.AddTransient<IRepository<Order>, EFOrderRepository>();

builder.Services.AddTransient<IBurgerService, BurgerService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IOrderService, OrderService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
