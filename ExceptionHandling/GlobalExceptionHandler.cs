// Purpose: Middleware to handle global exceptions and return a consistent error response. (USED IF WE ARE RUNNING A LOWER VERSION OF .NET)
/*
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Middleware
{
    public static class GlobalExceptionHandler
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Log the error
                        Console.WriteLine($"Something went wrong: {contextFeature.Error}");

                        // Create a response model if necessary
                        var errorDetails = new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please try again later.",
                            DetailedError = contextFeature.Error?.Message // Consider including this only in development
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
                    }
                });
            });
        }
    }
}
*/