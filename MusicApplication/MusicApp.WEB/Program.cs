using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Domain.Identity;
using MusicApp.Repository;
using MusicApp.Repository.Implementation;
using MusicApp.Repository.Interface;
using MusicApp.Service.Implementation;
using MusicApp.Service.Interface;
using Stripe;
//using MusicApp.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));

var connectionString1 = builder.Configuration.GetConnectionString("DefaultConnection") 
                        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var connectionString2 = builder.Configuration.GetConnectionString("AnotherConnection") 
                        ?? throw new InvalidOperationException("Connection string 'AnotherConnection' not found.");







// Add services to the container.
// Register DbContexts with their respective connection strings

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString1));


builder.Services.AddDbContext<SecondDbContext>(options =>
    options.UseSqlServer(connectionString2));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));


builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<ITrackService, TrackService>();
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserPlaylistService, UserPlaylistService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
