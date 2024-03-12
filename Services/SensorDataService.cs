using MQTTBrokerProject.Interfaces;
using MQTTBrokerProject.Models;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Services
{
    /// <summary>
    /// Service responsible for processing incoming sensor data.
    /// </summary>
    public class SensorDataService : ISensorDataService
    {
        /// <summary>
        /// Processes incoming sensor data asynchronously.
        /// </summary>
        /// <param name="data">The sensor data to process.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <remarks>
        /// This method is a placeholder for the actual data processing logic, 
        /// which could involve validation, conversion, storage, or further analysis.
        /// </remarks>
        public async Task ProcessSensorDataAsync(SensorData data)
        {
            // Example processing logic: log or store the received data.
            Console.WriteLine($"Processing sensor data: Temperature = {data.TempZs.Value}, Force = {data.Force.Value}");

            // In a real application, we must implement the actual data processing here

            await Task.CompletedTask;
        }
    }
}