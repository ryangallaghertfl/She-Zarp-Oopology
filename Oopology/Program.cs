using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oopology.Models;
using Oopology.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OopologyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OopologyContext") ?? throw new InvalidOperationException("Connection string 'OopologyContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
