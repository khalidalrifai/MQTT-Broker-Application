using System;

namespace MQTTBrokerProject.Models
{
    /// <summary>
    /// Container for various types of sensor data collected at the same instance.
    /// </summary>
    public class SensorData
    {
        // Temperature data associated with the sensor.
        public TemperatureData TempZs { get; set; }

        // Force data associated with the sensor.
        public ForceData Force { get; set; }
    }
}
