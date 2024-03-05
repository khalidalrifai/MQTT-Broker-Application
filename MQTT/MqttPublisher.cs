using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTBrokerProject.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MQTTBrokerProject.MQTT
{
    public class MqttPublisher
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientSettings _settings;

        public MqttPublisher(IOptions<MqttClientSettings> settings, IMqttClient mqttClient)
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
                    // Configure TLS options here based on your _settings
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
                Console.WriteLine("Connected to MQTT Broker.");
                // Handle post-connection actions here if necessary
            });

            _mqttClient.UseDisconnectedHandler(async e =>
            {
                Console.WriteLine("Disconnected from MQTT Broker.");
                // Reconnect or cleanup logic can go here
            });
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

        public async Task PublishAsync(string topic, string payload, bool retainFlag = false, int qos = 1)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)qos)
                .WithRetainFlag(retainFlag)
                .Build();

            await _mqttClient.PublishAsync(message);
        }
    }
}

