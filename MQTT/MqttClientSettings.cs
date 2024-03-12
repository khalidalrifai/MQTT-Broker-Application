using System;

namespace MQTTBrokerProject.Configurations
{
    // Configuration settings for the MQTT client.
    public class MqttClientSettings
    {
        // Unique identifier for the MQTT client. Defaults to a new GUID.
        public string ClientId { get; set; } = Guid.NewGuid().ToString();
        
        // Indicates whether the server should clean session data when the client disconnects. Defaults to true.
        public bool CleanSession { get; set; } = true;

        // The keep alive period specified in seconds. Determines the maximum time interval between messages from the client. Defaults to 60 seconds.
        public TimeSpan KeepAlivePeriod { get; set; } = TimeSpan.FromSeconds(60);

        // Indicates whether TLS security should be used for connections. Defaults to false.
        public bool UseTls { get; set; }

        // The host name or IP address of the MQTT broker.
        public string Host { get; set; }

        // The network port of the MQTT broker. Defaults to 1883, the standard MQTT port.
        public int Port { get; set; } = 1883; // Default MQTT port

        // TLS/SSL settings for secure connections.
        public TlsSettings TlsSettings { get; set; }

        // Credentials for authentication
        public string Username { get; set; }
        public string Password { get; set; }

        
        /// <summary>
        /// Reconnection settings
        /// </summary>
        
        // Indicates whether the client should automatically try to reconnect to the broker after a connection loss. Defaults to true.
        public bool AutoReconnect { get; set; } = true;

        // The delay before attempting to reconnect after a connection loss. Specified in seconds. Defaults to 5 seconds.
        public TimeSpan AutoReconnectDelay { get; set; } = TimeSpan.FromSeconds(5);

        // The default Quality of Service level for messages sent by this client. Defaults to 1.
        public int DefaultQoS { get; set; } = 1; // Default Quality of Service level for messages.
    }
}

