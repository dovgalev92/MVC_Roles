using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Roles.Context;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context_Data>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Access/LogIn"; // путь по которому будет перенаправлен не авторизованный пользователь
        options.AccessDeniedPath= "/GetResultSetting";//путь по которому будет перенаправлен польозователь в случае отсувствия доступа к определенным ресурсам
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CityRogachev", policy =>
    {
        policy.RequireClaim(ClaimTypes.Locality, "Рогачев", "Rogachev");
    });
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


app.MapControllers();

app.Run();
