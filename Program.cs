using Microsoft.Extensions.DependencyInjection;
using MQTTBrokerProject.Configurations;
using MQTTBrokerProject.Interfaces;
using MQTTBrokerProject.Security;
using MQTTBrokerProject.Services;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.Extensions;
using MQTTnet.Client;
using MQTTnet.Server;
using System.Net;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMqttClient>(new MqttFactory().CreateMqttClient());

// Configure services
builder.Services.Configure<MqttBrokerSettings>(builder.Configuration.GetSection("MqttBrokerSettings"));
builder.Services.Configure<MqttClientSettings>(builder.Configuration.GetSection("MqttClientSettings"));
builder.Services.AddSingleton<IMqttServer>(new MqttFactory().CreateMqttServer());
builder.Services.AddSingleton<IMqttAppService, MqttAppService>();
builder.Services.AddSingleton<ISensorDataService, SensorDataService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IAuthorizationService, AuthorizationManager>();

// MQTT Server configuration to use the default MQTT protocol endpoint
builder.Services.AddHostedMqttServer(mqttServer => mqttServer.WithDefaultEndpoint());

var app = builder.Build();

// Global exception handling configuration for non-development environments
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

                // Additional logging or actions based on the exception can be implemented here
            }
        });
    });
}

app.UseRouting();

// WebSocket configuration to enhance real-time communication capabilities
app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(120),
    ReceiveBufferSize = 4 * 1024 // 4 KB
});

// Placeholder for custom security middleware - to be implemented as per application security requirements
// app.UseMiddleware<CustomSecurityMiddleware>();

// Extension method to apply modular MQTT configuration
app.UseCustomMqttConfiguration();

// Start the MQTT Server with configuration loaded from appsettings.json and logging
var mqttSettings = app.Configuration.GetSection("MqttBrokerSettings").Get<MqttBrokerSettings>();
var mqttServer = app.Services.GetRequiredService<IMqttServer>();
mqttServer.StartAsync(new MqttServerOptionsBuilder()
    .WithDefaultEndpointPort(mqttSettings.Port)
    .Build()).GetAwaiter().GetResult();

app.Run();

// Extension method defined to add MQTT endpoints and any additional MQTT-related configurations
public static class MqttConfigurationExtensions
{
    public static IApplicationBuilder UseCustomMqttConfiguration(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMqtt("/mqtt"); // Map the MQTT endpoint
            // Here, additional endpoints for controllers or SignalR, etc., can be defined
        });

        // Additional MQTT-related configurations can be added here

        return app;
    }
}
