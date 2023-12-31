using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Confguration = builder.Configuration;

//DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Confguration.GetConnectionString
    ("DefaultConnectionString")));
// Add services to the container.
builder.Services.AddControllersWithViews();

//Services Configuration
builder.Services.AddScoped<IActorsService, ActorsService>();

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
