using DummyProject.Repository.ApplicationDbContext;
using DummyProject.Repository.IRepository;
using DummyProject.Repository.Repository;
using DummyProject.Service.IServices;
using DummyProject.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.LoginPath = "/Account/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(2);
        option.Cookie.HttpOnly = true;
        option.Cookie.IsEssential = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Place UseAuthentication before UseAuthorization
app.UseAuthorization();
app.UseSession(); // Place UseSession after UseRouting and before UseAuthorization

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();