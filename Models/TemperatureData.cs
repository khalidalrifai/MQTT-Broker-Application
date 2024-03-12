using System;

namespace MQTTBrokerProject.Models
{
    /// <summary>
    /// Represents temperature measurement data from a sensor.
    /// </summary>
    public class TemperatureData
    {
        // The measured temperature value.
        public string Value { get; set; }

        // The timestamp when the temperature measurement was taken.
        public DateTime Timestamp { get; set; }

        // A quality indicator for the temperature measurement, e.g., 0 for bad, 1 for good.
        public int Quality { get; set; }
    }
}
