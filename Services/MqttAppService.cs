using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Publishing;
using MQTTBrokerProject.Interfaces;
using System;
using System.Threading.Tasks;


namespace MQTTBrokerProject.Services
{
    /// <summary>
    /// Implements the <see cref="IMqttAppService"/> interface to manage MQTT client operations such as connecting,
    /// disconnecting, publishing, and subscribing.
    /// </summary>
    public class MqttAppService : IMqttAppService
    {
        private readonly IMqttClient _mqttClient;
        private readonly IMqttClientOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttAppService"/> class.
        /// </summary>
        /// <param name="mqttClient">The MQTT client instance for communication with the broker.</param>
        /// <param name="options">Configuration options for the MQTT client.</param>
        public MqttAppService(IMqttClient mqttClient, IMqttClientOptions options)
        {
            // Validate parameters are not null.
            _mqttClient = mqttClient ?? throw new ArgumentNullException(nameof(mqttClient));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Connects the MQTT client to the broker asynchronously using the provided options.
        /// </summary>
        public async Task ConnectAsync()
        {
            // Establish a connection if the client is not already connected.
            if (!_mqttClient.IsConnected)
            {
                await _mqttClient.ConnectAsync(_options);
            }
        }

        /// <summary>
        /// Disconnects the MQTT client from the broker asynchronously.
        /// </summary>
        public async Task DisconnectAsync()
        {
            // Disconnect if currently connected to the broker.
            if (_mqttClient.IsConnected)
            {
                await _mqttClient.DisconnectAsync();
            }
        }

        /// <summary>
        /// Publishes a message to the specified topic.
        /// </summary>
        /// <param name="topic">The topic to which the message will be published.</param>
        /// <param name="payload">The payload of the message.</param>
        /// <returns>A task that represents the asynchronous publish operation. The task result contains the publish result.</returns>
        public async Task<MqttClientPublishResult> PublishAsync(string topic, string payload)
        {
            // Build the message to publish.
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)       // Topic where the message will be published.
                .WithPayload(payload)   // Payload of the message.
                .WithExactlyOnceQoS()   // Using QoS level 2 (Exactly once) for message delivery guarantee.
                .Build();

            // Publish the message asynchronously and return the result.
            return await _mqttClient.PublishAsync(message);
        }

        /// <summary>
        /// Subscribes to messages on the specified topic.
        /// </summary>
        /// <param name="topic">The topic to subscribe to.</param>
        /// <param name="handler">The handler that will process received messages.</param>
        /// <returns>A task that represents the asynchronous subscribe operation.</returns>
        public async Task SubscribeAsync(string topic, Func<MqttApplicationMessageReceivedEventArgs, Task> handler)
        {
            // Set the message received handler.
            _mqttClient.UseApplicationMessageReceivedHandler(e => handler(e));
            // Subscribe to the specified topic.
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
        }
    }
}