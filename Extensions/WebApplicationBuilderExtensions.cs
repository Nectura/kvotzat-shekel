using KvotzatShekel.Database;
using KvotzatShekel.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace KvotzatShekel.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kvotzat Shekel", Version = "v1" });
        });
    }
    
    public static void RegisterDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Database") ?? throw new Exception("Database connection string is null");
        
        builder.Services.AddDbContext<IEntityContext, EntityContext>(options =>
        {
            options.UseNpgsql(connectionString).LogTo(Console.WriteLine, LogLevel.Warning);
            //.EnableSensitiveDataLogging()
            //.EnableDetailedErrors();
        });
    }
}