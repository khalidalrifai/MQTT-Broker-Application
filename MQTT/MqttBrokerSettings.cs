using System;

namespace MQTTBrokerProject.Configurations
{
    public class MqttBrokerSettings
    {
        public string Host { get; set; }
        public int Port { get; set; } = 1883; // Default MQTT port
        public int SecurePort { get; set; } = 8883; // Default MQTT SSL port
        public bool UseTls { get; set; }

        // TLS/SSL Settings
        public TlsSettings TlsSettings { get; set; }

        // Authentication
        public string Username { get; set; }
        public string Password { get; set; }

        // Broker specific settings
        public int ConnectionBacklog { get; set; } = 100; // Example: Maximum number of pending connections.
        public bool RetainMessages { get; set; } = false; // Example: Broker retains messages or not.
    }
}
