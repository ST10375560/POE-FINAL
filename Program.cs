using AgriEnergyConnectWebApp.Data;       // Namespace for the application's DbContext
using Microsoft.EntityFrameworkCore;       // Required for EF Core and UseNpgsql

// Create a new WebApplication builder with command-line arguments
var builder = WebApplication.CreateBuilder(args);


// Register the AppDbContext with the service container and configure it to use PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    // Uses the "DefaultConnection" string from appsettings.json
);

// Register support for MVC (Model-View-Controller) pattern
builder.Services.AddControllersWithViews();

// Enable in-memory caching, required for storing session state
builder.Services.AddDistributedMemoryCache();

// Configure and add session support
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout after 30 minutes of inactivity
    options.Cookie.HttpOnly = true;                 // Prevent client-side scripts from accessing the session cookie
    options.Cookie.IsEssential = true;              // Ensure the session cookie is sent even if user declines non-essential cookies
});

// Build the configured WebApplication
var app = builder.Build();


// Use a custom error handler if the app is not running in Development mode
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Redirects to the Error view on unhandled exceptions
}

// Enable serving of static files (e.g., CSS, JS, images)
app.UseStaticFiles();

// Enable routing (must come before session, auth, and endpoints)
app.UseRouting();

// Enable session handling
app.UseSession();

// Enable authentication middleware
app.UseAuthentication(); // (Only needed if Identity or custom auth is configured)

// Enable authorization middleware
app.UseAuthorization();

// Map the default controller route (e.g., HomeController and Index action)
app.MapDefaultControllerRoute();

// Start the application and listen for HTTP requests
app.Run();
