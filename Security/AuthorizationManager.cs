using System;
using System.Collections.Generic;
using MQTTBrokerProject.Interfaces;

namespace MQTTBrokerProject.Security
{
    public class AuthorizationManager : IAuthorizationService
    {
        private readonly Dictionary<string, List<string>> _userPermissions;

        public AuthorizationManager()
        {
            // Example permissions; adjust according to your needs.
            _userPermissions = new Dictionary<string, List<string>>
            {
                { "user1", new List<string> { "publish/sensors/temperature", "subscribe/sensors/+" } },
                // "+" indicates subscription to all topics under "sensors/"
                { "user2", new List<string> { "subscribe/sensors/temperature" } }
                // Add more as needed.
            };
        }

        public bool IsAuthorized(string username, string operation)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(operation))
            {
                return false;
            }

            if (_userPermissions.TryGetValue(username, out var permissions))
            {
                return permissions.Contains(operation);
            }

            return false;
        }
    }
}

