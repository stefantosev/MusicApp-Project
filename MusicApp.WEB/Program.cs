using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Identity;
using MusicApp.Repository;
using MusicApp.Repository.Implementation;
using MusicApp.Repository.Interface;
using MusicApp.Service.Implementation;
using MusicApp.Service.Interface;
//using MusicApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IArtistService, ArtistService>();

builder.Services.AddTransient<ITrackService, TrackService>();
builder.Services.AddTransient<IUserPlaylistService, UserPlaylistService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
