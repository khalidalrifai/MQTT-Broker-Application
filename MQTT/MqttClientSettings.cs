using System;

namespace MQTTBrokerProject.Configurations
{
    public class MqttClientSettings
    {
        public string ClientId { get; set; } = Guid.NewGuid().ToString();
        public bool CleanSession { get; set; } = true;
        public TimeSpan KeepAlivePeriod { get; set; } = TimeSpan.FromSeconds(60);
        public bool UseTls { get; set; }

        // Added Host and Port properties
        public string Host { get; set; }
        public int Port { get; set; } = 1883; // Default MQTT port

        public TlsSettings TlsSettings { get; set; }

        // Credentials for authentication
        public string Username { get; set; }
        public string Password { get; set; }

        // Reconnection settings
        public bool AutoReconnect { get; set; } = true;
        public TimeSpan AutoReconnectDelay { get; set; } = TimeSpan.FromSeconds(5);

        // Message settings
        public int DefaultQoS { get; set; } = 1; // Default Quality of Service level for messages.
    }
}

