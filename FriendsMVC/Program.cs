using FriendsMVC.Buisness.Contract.Interfaces;
using FriendsMVC.Buisness.Services;
using FriendsMVC.DataAccess;
using FriendsMVC.Logging;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI for dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionMySQL"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnectionMySQL"))).LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());



//if development
#if DEBUG
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<ICountryService, CountryService>();
#endif

SerilogConfigurator.ConfigureSerilog(builder, LogLevel.Warning, "log.txt");

var app = builder.Build();

//StartUp.MigrateDB(app.Services);

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
    pattern: "{controller=Friend}/{action=Index}/{id?}");

app.Run();


