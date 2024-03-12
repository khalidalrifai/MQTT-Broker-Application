using System;
using MQTTBrokerProject.Interfaces;
using System.Collections.Generic;

namespace MQTTBrokerProject.Services
{
    /// <summary>
    /// Provides services for authenticating users based on username and password or a token.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        // Example user storage. In a real application, consider a more secure storage mechanism.
        // A dictionary to simulate user storage. In production, use a secure mechanism like a database with hashed passwords.
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            {"user1", "password1"}, // Example: Hardcoded credentials for demonstration. Not secure or scalable for real applications.
            // Additional users can be added here.
        };

        /// <summary>
        /// Validates user credentials against the stored credentials.
        /// </summary>
        /// <param name="username">The username provided for authentication.</param>
        /// <param name="password">The password provided for authentication.</param>
        /// <returns>True if the username and password match the stored credentials; otherwise, false.</returns>
        public bool ValidateCredentials(string username, string password)
        {
            // Check for null or empty inputs, which are automatically considered invalid.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Attempt to find the user's stored password and compare it to the provided password.
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        /// <summary>
        /// Validates a given authentication token. This method is a placeholder and should be implemented based on your token validation logic.
        /// </summary>
        /// <param name="token">The token to validate.</param>
        /// <returns>True if the token is considered valid; otherwise, false.</returns>
        /// <remarks>This implementation is simplistic and for demonstration purposes only. Implement actual token validation logic for production.</remarks>
        public bool ValidateToken(string token)
        {
            // A simplistic token validation that checks the token is not empty.
            // In a real scenario, this method should verify the token's integrity, expiry, and possibly other claims depending on your security requirements.
            return !string.IsNullOrEmpty(token); // Simplistic check for example purposes.
        }
    }
}

