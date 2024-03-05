using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Publishing;
using MQTTBrokerProject.Interfaces;
using System;
using System.Threading.Tasks;


namespace MQTTBrokerProject.Services
{
    public class MqttAppService : IMqttAppService
    {
        private readonly IMqttClient _mqttClient;
        private readonly IMqttClientOptions _options;

        public MqttAppService(IMqttClient mqttClient, IMqttClientOptions options)
        {
            _mqttClient = mqttClient ?? throw new ArgumentNullException(nameof(mqttClient));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task ConnectAsync()
        {
            if (!_mqttClient.IsConnected)
            {
                await _mqttClient.ConnectAsync(_options);
            }
        }

        public async Task DisconnectAsync()
        {
            if (_mqttClient.IsConnected)
            {
                await _mqttClient.DisconnectAsync();
            }
        }

        public async Task<MqttClientPublishResult> PublishAsync(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithExactlyOnceQoS()
                .Build();

            return await _mqttClient.PublishAsync(message);
        }

        public async Task SubscribeAsync(string topic, Func<MqttApplicationMessageReceivedEventArgs, Task> handler)
        {
            _mqttClient.UseApplicationMessageReceivedHandler(e => handler(e));
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
        }
    }
}