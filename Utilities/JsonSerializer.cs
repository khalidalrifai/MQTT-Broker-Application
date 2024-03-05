using System;
using System.Text.Json;

namespace MQTTBrokerProject.Utilities
{
    public static class JsonSerializer
    {
        public static string Serialize<T>(T data)
        {
            try
            {
                // Fully qualify the JsonSerializer to avoid naming conflict
                return System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException($"Error serializing object of type {typeof(T)}", ex);
            }
        }

        public static T Deserialize<T>(string jsonData)
        {
            try
            {
                // Fully qualify the JsonSerializer to avoid naming conflict
                return System.Text.Json.JsonSerializer.Deserialize<T>(jsonData);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException($"Error deserializing JSON to object of type {typeof(T)}", ex);
            }
        }
    }
}
