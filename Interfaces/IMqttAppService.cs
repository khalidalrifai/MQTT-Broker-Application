using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Publishing;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Interfaces
{
    /// <summary>
    /// Manages MQTT client operations such as connecting, disconnecting, publishing, and subscribing.
    /// </summary>
    public interface IMqttAppService
    {
        // Connects the MQTT client to the broker asynchronously.
        Task ConnectAsync();

        // Disconnects the MQTT client from the broker asynchronously.
        Task DisconnectAsync();

        /// <summary>
        /// Publishes a message to the specified topic.
        /// </summary>
        /// <param name="topic">The topic where the message should be published.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The result of the publish operation.</returns>
        Task<MqttClientPublishResult> PublishAsync(string topic, string payload);

        /// <summary>
        /// Subscribes to a specified topic and defines a handler for incoming messages.
        /// </summary>
        /// <param name="topic">The topic to subscribe to.</param>
        /// <param name="handler">The function to handle incoming messages.</param>
        Task SubscribeAsync(string topic, Func<MqttApplicationMessageReceivedEventArgs, Task> handler);

        // Additional methods as needed.
    }
}
