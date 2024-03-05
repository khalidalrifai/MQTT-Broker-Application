using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTBrokerProject.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace MQTTBrokerProject.MQTT
{
    public class MqttSubscriber : IMqttApplicationMessageReceivedHandler
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientSettings _settings;

        public MqttSubscriber(IOptions<MqttClientSettings> settings, IMqttClient mqttClient)
        {
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
            _mqttClient = mqttClient ?? throw new ArgumentNullException(nameof(mqttClient));
            InitializeMqttClient();
        }

        private void InitializeMqttClient()
        {
            var builder = new MqttClientOptionsBuilder()
                .WithClientId(_settings.ClientId)
                .WithTcpServer(_settings.Host, _settings.Port);

            if (_settings.UseTls)
            {
                builder.WithTls(options =>
                {
                    // Configure TLS options based on your settings
                    options.SslProtocol = System.Security.Authentication.SslProtocols.Tls12;
                });
            }

            if (!string.IsNullOrEmpty(_settings.Username) && !string.IsNullOrEmpty(_settings.Password))
            {
                builder.WithCredentials(_settings.Username, _settings.Password);
            }

            var mqttOptions = builder.Build();

            _mqttClient.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Connected to MQTT Broker as subscriber.");
                // Handle post-connection actions here if necessary
            });

            _mqttClient.UseDisconnectedHandler(async e =>
            {
                Console.WriteLine("Disconnected from MQTT Broker.");
                // Reconnect or cleanup logic can go here
            });

            _mqttClient.UseApplicationMessageReceivedHandler(this);
        }

        public async Task ConnectAsync()
        {
            if (!_mqttClient.IsConnected)
            {
                await _mqttClient.ConnectAsync(_mqttClient.Options);
            }
        }

        public async Task DisconnectAsync()
        {
            if (_mqttClient.IsConnected)
            {
                await _mqttClient.DisconnectAsync();
            }
        }

        public async Task SubscribeAsync(string topic, int qos = 1)
        {
            if (!_mqttClient.IsConnected)
            {
                await ConnectAsync();
            }
            await _mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)qos).Build());
            Console.WriteLine($"Subscribed to {topic}");
        }

        // Implementation of IMqttApplicationMessageReceivedHandler
        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            // Process received message
            Console.WriteLine($"Message received on topic {eventArgs.ApplicationMessage.Topic}: {eventArgs.ApplicationMessage.ConvertPayloadToString()}");
            return Task.CompletedTask;
        }
    }
}
