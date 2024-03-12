using System;

namespace MQTTBrokerProject.Configurations
{
    /// <summary>
    /// Configuration settings for the MQTT broker.
    /// </summary>
    public class MqttBrokerSettings
    {
        // The host name or IP address where the MQTT broker is running.
        public string Host { get; set; }

        // The network port for unsecured MQTT connections. Defaults to 1883.
        public int Port { get; set; } = 1883; // Default MQTT port

        // The network port for secured MQTT connections (using TLS/SSL). Defaults to 8883.
        public int SecurePort { get; set; } = 8883; // Default MQTT SSL port

        // Indicates whether TLS/SSL is enabled for the broker. Defaults to false.
        public bool UseTls { get; set; }

        // TLS/SSL settings for secure connections.
        public TlsSettings TlsSettings { get; set; }

        // Authentication
        public string Username { get; set; }    // Optional username for broker authentication.
        public string Password { get; set; }    // Optional password for broker authentication.

        /// <summary>
        /// Broker specific settings
        /// </summary>
        // The maximum number of pending connections the broker will hold. Defaults to 100.
        public int ConnectionBacklog { get; set; } = 100; // Example: Maximum number of pending connections.
        
        // Indicates whether the broker retains messages for future subscribers. Defaults to false.
        public bool RetainMessages { get; set; } = false; // Example: Broker retains messages or not.
    }
}
