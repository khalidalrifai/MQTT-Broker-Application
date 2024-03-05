using MQTTBrokerProject.Models;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Interfaces
{
    public interface ISensorDataService
    {
        Task ProcessSensorDataAsync(SensorData data);
        // Methods for specific operations on sensor data, e.g., validation, transformation, etc., can be added here.
    }
}
