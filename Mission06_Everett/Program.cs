using Microsoft.EntityFrameworkCore;
using Mission06_Everett.Models;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Add MVC services to the dependency injection container
builder.Services.AddControllersWithViews();

// Configure the database context to use SQLite with connection string from appsettings.json
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline for production environments
if (!app.Environment.IsDevelopment())
{
    // Use custom error handler in production
    app.UseExceptionHandler("/Home/Error");

    // Enable HTTP Strict Transport Security (HSTS) for security
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable routing middleware
app.UseRouting();

// Enable authorization middleware
app.UseAuthorization();

// Map static assets (CSS, JS, images)
app.MapStaticAssets();

// Configure default route pattern for MVC controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Start the application
app.Run();
