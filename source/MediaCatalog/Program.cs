// File: Program.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediaCatalog.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext and SQLite
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Register controllers (if using minimal APIs, you might skip this, but for MVC controllers:
builder.Services.AddControllers();

// Add CORS if needed (optional but good practice for API)
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(); // Enable CORS
app.UseAuthorization();

app.MapControllers(); // Map MVC controllers
// app.MapControllers(); // Or MapEndpoints() if using Minimal APIs
// Or: app.MapGet("/", () => "Hello Movie Catalog!");

// Create database if it doesn't exist (for development simplicity)
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MovieContext>();
context.Database.EnsureCreated();

app.Run();

// ... rest of application logic ...