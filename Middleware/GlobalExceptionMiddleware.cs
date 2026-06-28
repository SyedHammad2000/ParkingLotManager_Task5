using Microsoft.AspNetCore.Mvc;
using ParkingLotAPI.Exceptions;
using System.Text.Json;

namespace ParkingLotAPI.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static async Task HandleException(
        HttpContext context,
        Exception ex)
    {
        var statusCode = ex switch
        {
            SpotNotAvailableException => StatusCodes.Status404NotFound,

            TicketNotFoundException => StatusCodes.Status404NotFound,

            TicketAlreadyClosedException => StatusCodes.Status409Conflict,

            InvalidVehicleTypeException => StatusCodes.Status400BadRequest,

            _ => StatusCodes.Status500InternalServerError
        };

        context.Response.StatusCode = statusCode;

        context.Response.ContentType = "application/problem+json";

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = ex.GetType().Name,
            Detail = ex.Message
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(problem));
    }
}