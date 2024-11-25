using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task2product.Context;
using Task2product.Factories;
using Task2product.Interface;

using Task2product.Models;

using Task2product.Service;
using static Task2product.Models.Product2;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductContext2>(options =>
{
    var ctr = builder.Configuration.GetConnectionString("CON");
    options.UseSqlServer(ctr);
});
builder.Services.AddScoped<Product2Interface, Product2Service>();


builder.Services.AddScoped<ICustomerService, Customerservice>();
builder.Services.AddScoped<ICustomerRolesService,CustomerRolesService>();
builder.Services.AddScoped<IRoleMap,RoleMapService>();
builder.Services.AddScoped<ICartService, CartService>();


builder.Services.AddScoped<IFactory, FCustomer>();
builder.Services.AddScoped<IFCustomerRoles, FCustomerRoles>();
builder.Services.AddScoped<IFRoleMap, FRoleMap>();
builder.Services.AddScoped<ICartFactory, CartFactory>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
    options.AddPolicy("GuestOnly", policy => policy.RequireRole("Guest"));
});


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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
