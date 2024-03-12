using System;
using System.Collections.Generic;
using MQTTBrokerProject.Interfaces;

namespace MQTTBrokerProject.Security
{
    /// <summary>
    /// Manages authorization by checking if a user is permitted to perform specific operations.
    /// </summary>
    public class AuthorizationManager : IAuthorizationService
    {
        // Holds permissions for each user. Each entry maps a username to a list of allowed operations.
        private readonly Dictionary<string, List<string>> _userPermissions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationManager"/> class.
        /// </summary>
        public AuthorizationManager()
        {
            // Initializes user permissions. In a real application, permissions would likely come from a database or external service.
            _userPermissions = new Dictionary<string, List<string>>
            {
                // Example: "user1" can publish to "sensors/temperature" and subscribe to all "sensors/" topics.
                { "user1", new List<string> { "publish/sensors/temperature", "subscribe/sensors/+" } },
                // The "+" wildcard indicates permission for all subtopics under "sensors/".
                
                // Example: "user2" is only allowed to subscribe to "sensors/temperature".
                { "user2", new List<string> { "subscribe/sensors/temperature" } }
                
                // Additional users and their permissions can be added as needed.
            };
        }

        /// <summary>
        /// Determines if the specified user is authorized to perform the given operation.
        /// </summary>
        /// <param name="username">The username of the user attempting the operation.</param>
        /// <param name="operation">The operation being attempted. Expected format: "action/topic", e.g., "publish/sensors/temperature".</param>
        /// <returns><c>true</c> if the user is authorized for the operation; otherwise, <c>false</c>.</returns>
        public bool IsAuthorized(string username, string operation)
        {
            // Validates input parameters.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(operation))
            {
                return false;
            }

            // Checks if the user has permissions for the requested operation.
            if (_userPermissions.TryGetValue(username, out var permissions))
            {
                // The operation is authorized if it's contained in the user's list of permissions.
                return permissions.Contains(operation);
            }

            // The user is not authorized if their username is not found or the operation is not in their permissions list.
            return false;
        }
    }
}
