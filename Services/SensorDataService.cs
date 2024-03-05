using MQTTBrokerProject.Interfaces;
using MQTTBrokerProject.Models;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Services
{
    public class SensorDataService : ISensorDataService
    {
        public async Task ProcessSensorDataAsync(SensorData data)
        {
            // Placeholder for processing logic
            // This could involve validation, conversion, storage, or further analysis

            // Example: Log or store the received data
            Console.WriteLine($"Processing sensor data: Temperature = {data.TempZs.Value}, Force = {data.Force.Value}");

            await Task.CompletedTask;
        }
    }
}
