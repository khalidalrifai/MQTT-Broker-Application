using MQTTBrokerProject.Configurations;
using MQTTBrokerProject.Interfaces;
using MQTTBrokerProject.Security;
using MQTTBrokerProject.Services;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.Extensions;
using MQTTnet.Server;
using System.Net;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.Configure<MqttBrokerSettings>(builder.Configuration.GetSection("MqttBrokerSettings"));
builder.Services.Configure<MqttClientSettings>(builder.Configuration.GetSection("MqttClientSettings"));
builder.Services.AddSingleton<IMqttServer>(new MqttFactory().CreateMqttServer());
builder.Services.AddSingleton<IMqttAppService, MqttAppService>();
builder.Services.AddSingleton<ISensorDataService, SensorDataService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IAuthorizationService, AuthorizationManager>();

// MQTT Server configuration
builder.Services.AddHostedMqttServer(mqttServer => mqttServer.WithDefaultEndpoint());

var app = builder.Build();

// Global exception handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var exceptionHandlerFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
            if (exceptionHandlerFeature != null)
            {
                var error = new { message = "An unexpected error occurred. Please try again later." };
                await context.Response.WriteAsync(JsonSerializer.Serialize(error));

                // Optionally log the exception or perform other actions
            }
        });
    });
}

app.UseRouting();

// Enhanced WebSocket Configuration (if using WebSockets directly, consider this configuration)
app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(120),
    ReceiveBufferSize = 4 * 1024 // 4 KB
});

// Placeholder for Custom Security Middleware (implement this middleware according to your security needs)
// app.UseMiddleware<CustomSecurityMiddleware>();

// Modularized MQTT Configuration
app.UseCustomMqttConfiguration();

// Start MQTT Server with Dynamic Configuration and Logging
var mqttSettings = app.Configuration.GetSection("MqttBrokerSettings").Get<MqttBrokerSettings>();
var mqttServer = app.Services.GetRequiredService<IMqttServer>();
mqttServer.StartAsync(new MqttServerOptionsBuilder()
    .WithDefaultEndpointPort(mqttSettings.Port)
    .Build()).GetAwaiter().GetResult();

app.Run();

// Extension method for modular MQTT configuration
public static class MqttConfigurationExtensions
{
    public static IApplicationBuilder UseCustomMqttConfiguration(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMqtt("/mqtt");
            // Map other controllers or signalR etc., if needed
        });

        // Any other MQTT-related configuration can go here

        return app;
    }
}
