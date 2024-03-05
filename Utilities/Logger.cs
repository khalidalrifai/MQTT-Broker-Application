using Microsoft.Extensions.Logging;
using System;

namespace MQTTBrokerProject.Utilities
{
    public class AppLogger<T> where T : class
    {
        private readonly ILogger<T> _logger;

        public AppLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }

        // Additional methods for Debug, Trace, Critical can be added similarly.
    }
}
