using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Interfaces.WorkUnits;
using KvotzatShekel.Database.Repositories.Abstract;
using KvotzatShekel.Database.WorkUnits;
using KvotzatShekel.Endpoints;
using KvotzatShekel.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterSwagger();
builder.RegisterDatabase();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IFactoryRepository, FactoryRepository>();
builder.Services.AddScoped<IFactoryToCustomerRepository, FactoryToCustomerRepository>();

builder.Services.AddScoped<ICustomerWorkUnit, CustomerWorkUnit>();

var app = builder.Build();
app.UseGlobalExceptionHandling();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.EnableTryItOutByDefault();
});

app.MapCustomerEndpoints();

app.Run();