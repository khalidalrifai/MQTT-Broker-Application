namespace MQTTBrokerProject.Configurations
{
    public class ClientConfig
    {
        public string ClientId { get; set; }
        public bool CleanSession { get; set; }
        public int KeepAlivePeriod { get; set; }
        public int DefaultQoS { get; set; }
        public TimestampGroupingConfig TimestampGrouping { get; set; }
    }

    public class TimestampGroupingConfig
    {
        public bool Enabled { get; set; }
        public int GroupingIntervalSeconds { get; set; }
    }
}
