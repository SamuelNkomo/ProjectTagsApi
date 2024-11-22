using Microsoft.EntityFrameworkCore;
using ProjectTagsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProjectTagsContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProjectTagsData"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Retry up to 5 times
            maxRetryDelay: TimeSpan.FromSeconds(10), // Wait 10 seconds between retries
            errorNumbersToAdd: null // Handle default transient errors
        )
    )
);

// Add controllers.
builder.Services.AddControllers();

// Add Swagger/OpenAPI support.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable middleware for Swagger in development environments.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware for HTTPS redirection.
app.UseHttpsRedirection();

// Middleware for authorization.
app.UseAuthorization();

// Map controllers to endpoints.
app.MapControllers();

// Run the application.
app.Run();

