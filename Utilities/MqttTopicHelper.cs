using System;

namespace MQTTBrokerProject.Utilities
{
    /// <summary>
    /// Provides utility methods for working with MQTT topics, such as creating or parsing topics.
    /// </summary>
    public static class MqttTopicHelper
    {
        /// <summary>
        /// Constructs a topic string using a base topic and a sensor type.
        /// </summary>
        /// <param name="baseTopic">The base part of the topic.</param>
        /// <param name="sensorType">The sensor type to append to the base topic.</param>
        /// <returns>A constructed MQTT topic string.</returns>
        public static string CreateTopic(string baseTopic, string sensorType)
        {
            return $"{baseTopic}/{sensorType}";
        }

        /// <summary>
        /// Attempts to parse a topic string into its base topic and sensor type components.
        /// </summary>
        /// <param name="topic">The MQTT topic string to parse.</param>
        /// <param name="baseTopic">Output parameter to store the base topic if parsing is successful.</param>
        /// <param name="sensorType">Output parameter to store the sensor type if parsing is successful.</param>
        /// <returns>True if parsing is successful; otherwise, false.</returns>
        public static bool TryParseTopic(string topic, out string baseTopic, out string sensorType)
        {
            var segments = topic.Split('/');
            if (segments.Length == 2)
            {
                baseTopic = segments[0];
                sensorType = segments[1];
                return true;
            }

            baseTopic = null;
            sensorType = null;
            return false;
        }

        // Additional methods can be added based on your topic structure and requirements, such as topic validation or segmentation.
    }
}
