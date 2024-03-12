using System;
using System.Text.Json;

namespace MQTTBrokerProject.Utilities
{
    /// <summary>
    /// Provides utility methods for serializing objects to JSON strings and deserializing JSON strings to objects.
    /// </summary>
    public static class JsonSerializer
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="data">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        /// <exception cref="InvalidOperationException">Thrown when serialization fails.</exception>
        public static string Serialize<T>(T data)
        {
            try
            {
                // Serialize the object to a JSON string with indentation for readability.
                // System.Text.Json.JsonSerializer is fully qualified to avoid conflict with the name of this class.
                return System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                // If an error occurs during serialization, encapsulate it in a more specific exception.
                // This could be logged or handled further up the call stack as needed.
                throw new InvalidOperationException($"Error serializing object of type {typeof(T)}", ex);
            }
        }

        /// <summary>
        /// Deserializes a JSON string to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="jsonData">The JSON string to deserialize.</param>
        /// <returns>An object of type T populated with data from the JSON string.</returns>
        /// <exception cref="InvalidOperationException">Thrown when deserialization fails.</exception>
        public static T Deserialize<T>(string jsonData)
        {
            try
            {
                // Deserialize the JSON string to an object of type T.
                // System.Text.Json.JsonSerializer is fully qualified to avoid conflict with the name of this class.
                return System.Text.Json.JsonSerializer.Deserialize<T>(jsonData);
            }
            catch (Exception ex)
            {
                // If an error occurs during deserialization, encapsulate it in a more specific exception.
                // This could be logged or handled further up the call stack as needed.
                throw new InvalidOperationException($"Error deserializing JSON to object of type {typeof(T)}", ex);
            }
        }
    }
}
