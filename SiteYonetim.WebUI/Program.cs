using SiteYonetim.Business.Abstract;
using SiteYonetim.Business.Concrete;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.DataAccess.Concrete;
using SiteYonetim.DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Veritabanı Bağlantısı (Context)
builder.Services.AddDbContext<SiteYonetimContext>();

// 2. Generic Repository Tanımlaması (Dependency Injection)
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

// 3. Manager Sınıflarının Tanımlanması
builder.Services.AddScoped<IApartmentService, ApartmentManager>();
builder.Services.AddScoped<IApartmentDal, EfApartmentDal>();
builder.Services.AddScoped<IBlockService, BlockManager>();
builder.Services.AddScoped<IApartmentService, ApartmentManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IDuesService, DuesManager>();
builder.Services.AddScoped<IDuesDal, EfDuesDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index"; // Giriş yapmamış biri gelirse buraya at
        x.AccessDeniedPath = "/Login/AccessDenied"; // Yetkisiz erişimlerde yönlendirilecek sayfa
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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();