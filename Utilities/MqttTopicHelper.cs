using System;

namespace MQTTBrokerProject.Utilities
{
    public static class MqttTopicHelper
    {
        public static string CreateTopic(string baseTopic, string sensorType)
        {
            return $"{baseTopic}/{sensorType}";
        }

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

        // Add more methods as needed based on your topic structure and requirements
    }
}
