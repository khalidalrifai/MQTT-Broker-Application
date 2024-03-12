using System;

namespace MQTTBrokerProject.Exceptions
{
    // General application exception
    /// <summary>
    /// Represents errors that occur during application execution.
    /// This class serves as the base class for more specific application exceptions.
    /// </summary>
    public class ApplicationException : Exception
    {
        // Initializes a new instance of the ApplicationException class.
        public ApplicationException() { }

        // Initializes a new instance of the ApplicationException class with a specified error message.
        public ApplicationException(string message) : base(message) { }

        // Initializes a new instance of the ApplicationException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        public ApplicationException(string message, Exception inner) : base(message, inner) { }
    }

    // Specific exceptions related to MQTT operations
    /// <summary>
    /// Represents errors that occur during the connection process to the MQTT broker.
    /// </summary>
    public class MqttConnectionException : ApplicationException
    {
        // Initializes a new instance of the MqttConnectionException class.
        public MqttConnectionException() { }


        // Initializes a new instance of the MqttConnectionException class with a specified error message.
        public MqttConnectionException(string message) : base(message) { }


        // Initializes a new instance of the MqttConnectionException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        public MqttConnectionException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// Represents errors that occur during the publishing of messages to the MQTT broker.
    /// </summary>
    public class MqttPublishException : ApplicationException
    {
        // Initializes a new instance of the MqttPublishException class.
        public MqttPublishException() { }

        // Initializes a new instance of the MqttPublishException class with a specified error message.
        public MqttPublishException(string message) : base(message) { }

        // Initializes a new instance of the MqttPublishException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        public MqttPublishException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// Represents errors that occur during the subscription process to MQTT topics.
    /// </summary>
    public class MqttSubscriptionException : ApplicationException
    {
        // Initializes a new instance of the MqttSubscriptionException class.
        public MqttSubscriptionException() { }

        // Initializes a new instance of the MqttSubscriptionException class with a specified error message.
        public MqttSubscriptionException(string message) : base(message) { }


        // Initializes a new instance of the MqttSubscriptionException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        public MqttSubscriptionException(string message, Exception inner) : base(message, inner) { }
    }

    // Additional custom exceptions specific to your application's needs can be added here.
}

