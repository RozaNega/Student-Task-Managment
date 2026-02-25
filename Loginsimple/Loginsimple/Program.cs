using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Loginsimple.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LoginsimpleContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginsimpleContextConnection' not found.");;

builder.Services.AddDbContext<LoginsimpleContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LoginsimpleUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LoginsimpleContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();


app.Run();
