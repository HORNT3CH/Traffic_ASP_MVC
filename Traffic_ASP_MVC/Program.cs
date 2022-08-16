using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Traffic_ASP_MVC.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Traffic_Door_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Traffic_Door_Context") ?? throw new InvalidOperationException("Connection string 'Traffic_Door_Context' not found.")));
builder.Services.AddDbContext<Traffic_DockLot_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Traffic_DockLot_Context") ?? throw new InvalidOperationException("Connection string 'Traffic_DockLot_Context' not found.")));
builder.Services.AddDbContext<Traffic_Schedule_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Traffic_Schedule_Context") ?? throw new InvalidOperationException("Connection string 'Traffic_Schedule_Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCloudscribePagination();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
