using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using DNTCaptcha.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson();

// Sets up routing
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddDNTCaptcha(options =>
{
    options.UseCookieStorageProvider(SameSiteMode.Strict)
        .ShowThousandsSeparators(false)
        .WithEncryptionKey("encryptionkey");
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Adds db support
builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketContext"));
});

// Sets up the password
builder.Services.AddIdentity<Member, IdentityRole>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MarketContext>().AddDefaultTokenProviders();



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
app.UseSession();

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
