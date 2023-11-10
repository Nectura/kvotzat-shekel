using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Interfaces.WorkUnits;
using KvotzatShekel.Exceptions;
using KvotzatShekel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/customer/group-customers", async (
                HttpContext context,
                [FromServices] IFactoryToCustomerRepository groupRepository
            ) => await GetGroupCustomersAsync(context, groupRepository))
            .WithDescription("Get all customers separated by groups");
        
        endpoints.MapPost("/customer/create", async (
                HttpContext context,
                [FromServices] ICustomerWorkUnit workUnit,
                [FromBody] CustomerCreationRequestDTO request
            ) => await CreateCustomerAsync(context, workUnit, request))
            .WithDescription("Create a customer");
    }

    private static async Task<IResult> GetGroupCustomersAsync(
        HttpContext context,
        IFactoryToCustomerRepository factoryToCustomerRepository)
    {
        var groupedResults = await factoryToCustomerRepository
            .Query(m => true)
            .Select(m => new
            {
                Group = new GroupDTO
                {
                    Id = m.GroupId,
                    Name = m.Group.Name,
                },
                Customer = new GroupCustomerDTO
                {
                    Id = m.CustomerId,
                    Name = m.Customer.Name
                }
            })
            .GroupBy(m => m.Group)
            .ToDictionaryAsync(m => m.Key, m => m.Select(g => g.Customer).ToArray(), context.RequestAborted);

        if (groupedResults.Count == 0)
            return Results.NoContent();
        
        return Results.Ok(new GetGroupCustomersResponseDTO
        {
            Groups = groupedResults.Select(m => m.Key with { GroupCustomers = m.Value })
        });
    }

    private static async Task<IResult> CreateCustomerAsync(
        HttpContext context,
        ICustomerWorkUnit workUnit,
        CustomerCreationRequestDTO request)
    {
        if (string.IsNullOrWhiteSpace(request.Customer.Name))
            throw new HttpRequestErrorException(StatusCodes.Status400BadRequest, "Customer name is required");
        
        if (string.IsNullOrWhiteSpace(request.Customer.Address))
            throw new HttpRequestErrorException(StatusCodes.Status400BadRequest, "Customer address is required");
        
        if (string.IsNullOrWhiteSpace(request.Customer.PhoneNumber))
            throw new HttpRequestErrorException(StatusCodes.Status400BadRequest, "Customer phone number is required");

        try
        {
            await workUnit.CreateAsync(request, context.RequestAborted);
        }
        catch (ArgumentException ex)
        {
            throw new HttpRequestErrorException(StatusCodes.Status400BadRequest, ex.Message);
        }
        
        return Results.Created();
    }
}
    