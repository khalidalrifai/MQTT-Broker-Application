using System;

namespace MQTTBrokerProject.Models
{
    public class TemperatureData
    {
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quality { get; set; }
    }
}
