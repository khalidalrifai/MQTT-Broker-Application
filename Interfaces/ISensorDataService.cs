using MQTTBrokerProject.Models;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Interfaces
{
    /// <summary>
    /// Defines the service responsible for processing sensor data.
    /// </summary>
    public interface ISensorDataService
    {
        /// <summary>
        /// Processes sensor data asynchronously, potentially involving validation, storage, or analysis.
        /// </summary>
        /// <param name="data">The sensor data to process.</param>
        Task ProcessSensorDataAsync(SensorData data);
        // Methods for specific operations on sensor data, e.g., validation, transformation, etc., can be added here.
    }
}
