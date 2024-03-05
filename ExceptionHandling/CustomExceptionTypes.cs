using System;

namespace MQTTBrokerProject.Exceptions
{
    // General application exception
    public class ApplicationException : Exception
    {
        public ApplicationException() { }

        public ApplicationException(string message) : base(message) { }

        public ApplicationException(string message, Exception inner) : base(message, inner) { }
    }

    // Specific exceptions related to MQTT operations
    public class MqttConnectionException : ApplicationException
    {
        public MqttConnectionException() { }

        public MqttConnectionException(string message) : base(message) { }

        public MqttConnectionException(string message, Exception inner) : base(message, inner) { }
    }

    public class MqttPublishException : ApplicationException
    {
        public MqttPublishException() { }

        public MqttPublishException(string message) : base(message) { }

        public MqttPublishException(string message, Exception inner) : base(message, inner) { }
    }

    public class MqttSubscriptionException : ApplicationException
    {
        public MqttSubscriptionException() { }

        public MqttSubscriptionException(string message) : base(message) { }

        public MqttSubscriptionException(string message, Exception inner) : base(message, inner) { }
    }

    // Add other custom exceptions as necessary for your application
}

