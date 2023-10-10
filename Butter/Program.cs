using Butter.DataAccess;
using Butter.Repositories;
using Butter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddScoped<IUserRepository,UserRepository>(c => new UserRepository(builder.Configuration.GetConnectionString("dev")));
#endif
#if RELEASE
builder.Services.AddScoped<UserRepository>(c => new UserRepository(builder.Configuration.GetConnectionString("prod")));
#endif
#if STAGING
builder.Services.AddScoped<UserRepository>(c => new UserRepository(builder.Configuration.GetConnectionString("stag")));
#endif
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
