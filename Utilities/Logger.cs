using Microsoft.Extensions.Logging;
using System;

namespace MQTTBrokerProject.Utilities
{
    /// <summary>
    /// Provides a generic logging utility that wraps around the .NET Core ILogger.
    /// </summary>
    /// <typeparam name="T">The category for logging, typically the class where the logger is used.</typeparam>
    public class AppLogger<T> where T : class
    {
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Initializes a new instance of the AppLogger class.
        /// </summary>
        /// <param name="logger">The ILogger instance provided by the .NET Core logging framework.</param>
        public AppLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Logs a message at the Information level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        /// <summary>
        /// Logs a message at the Warning level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        /// <summary>
        /// Logs a message at the Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        /// <summary>
        /// Logs an exception and an associated message at the Error level.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message that describes the error.</param>
        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }

        // Additional methods for other log levels like Debug, Trace, Critical can be implemented in a similar manner.
    }
}
