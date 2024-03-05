using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Publishing;
using System.Threading.Tasks;

namespace MQTTBrokerProject.Interfaces
{
    public interface IMqttAppService
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        Task<MqttClientPublishResult> PublishAsync(string topic, string payload);
        Task SubscribeAsync(string topic, Func<MqttApplicationMessageReceivedEventArgs, Task> handler);

        // Additional methods as needed.
    }
}
