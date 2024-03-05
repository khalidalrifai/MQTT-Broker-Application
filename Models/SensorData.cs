using System;

namespace MQTTBrokerProject.Models
{
    public class SensorData
    {
        public TemperatureData TempZs { get; set; }
        public ForceData Force { get; set; }
    }
}
