using System;

namespace MQTTBrokerProject.Models
{
    /// <summary>
    /// Represents force measurement data from a sensor.
    /// </summary>
    public class ForceData
    {
        // The measured force value.
        public string Value { get; set; }
        
        // The timestamp when the force measurement was taken.
        public DateTime Timestamp { get; set; }

        // A quality indicator for the force measurement, e.g., 0 for bad, 1 for good.
        public int Quality { get; set; }
    }
}
