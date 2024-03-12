using System.Linq;

namespace MQTTBrokerProject.Configurations
{
    /// <summary>
    /// Represents the configuration settings specific to an MQTT client.
    /// </summary>
    public class ClientConfig
    {
        // Unique identifier for the MQTT client. Typically a GUID.
        public string ClientId { get; set; }

        // Indicates whether the server should store session data for the client. When false, the session starts clean each connection.
        public bool CleanSession { get; set; }

        // The maximum time interval in seconds between messages sent or received. Helps in determining the loss of connection with the broker.
        public int KeepAlivePeriod { get; set; }

        // The default quality of service level for the client's messages. Ranges from 0 (at most once) to 2 (exactly once).
        public int DefaultQoS { get; set; }

        // Configuration for timestamp grouping of messages.
        public TimestampGroupingConfig TimestampGrouping { get; set; }
    }

    /// <summary>
    /// Configuration related to the grouping of messages based on their timestamp.
    /// </summary>
    public class TimestampGroupingConfig
    {
        // Indicates whether timestamp grouping is enabled.
        public bool Enabled { get; set; }

        // The interval in seconds for grouping messages. Messages within this interval may be batched or processed together.
        public int GroupingIntervalSeconds { get; set; }
    }
}
