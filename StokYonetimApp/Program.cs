using Microsoft.Extensions.Configuration;
using StokYonetimApp.Context;
using StokYonetimApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// appsettings.json'dan baðlantý dizesini al
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

// Repository sýnýflarýný yapýlandýr
builder.Services.AddScoped<CategoryRepository>(provider => new CategoryRepository(connectionString));
builder.Services.AddScoped<ProductsRepository>(provider => new ProductsRepository(connectionString));
builder.Services.AddScoped<StockMovementsRepository>(provider => new StockMovementsRepository(connectionString));
builder.Services.AddScoped<PriceHistoryRepository>(provider => new PriceHistoryRepository(connectionString));



builder.Services.AddScoped<DataContext>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
