// Purpose: Middleware to handle global exceptions and return a consistent error response. (USED IF WE ARE RUNNING A LOWER VERSION OF .NET | .NET < V7)
/**/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Middleware
{
    /// <summary>
    /// Extension method for adding global exception handling to the application's request processing pipeline.
    /// This middleware captures unhandled exceptions, logs them, and returns a generic error response.
    /// </summary>
    public static class GlobalExceptionHandler
    {
        /// <summary>
        /// Configures the application to use a custom global exception handler.
        /// </summary>
        /// <param name="app">Defines a class that provides the mechanisms to configure an application's request pipeline.</param>
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            // Configure the application to use a centralized exception handling logic.
            app.UseExceptionHandler(appError =>
            {
                // Define the response and handling logic for unhandled exceptions.
                appError.Run(async context =>
                {
                    // Set the HTTP status code to Internal Server Error (500).
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    // Set the response content type to application/json.
                    context.Response.ContentType = "application/json";

                    // Retrieve exception details from the current HTTP context.
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Optionally log the error to the console or a log file.
                        Console.WriteLine($"Something went wrong: {contextFeature.Error}");

                        // Prepare a generic error response. You might want to customize this part
                        // based on whether the app is in development or production.
                        var errorDetails = new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please try again later.",
                            DetailedError = contextFeature.Error?.Message   // Include detailed error info conditionally
                        };

                        // Serialize the error details object to JSON and write it to the response body.
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
                    }
                });
            });
        }
    }
}
