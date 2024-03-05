using System;
using MQTTBrokerProject.Interfaces;
using System.Collections.Generic;

namespace MQTTBrokerProject.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        // Example user storage. In a real application, consider a more secure storage mechanism.
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            {"user1", "password1"}, // Example credentials
            // Add more users as needed.
        };

        public bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        public bool ValidateToken(string token)
        {
            // Token validation logic here. Placeholder implementation:
            return !string.IsNullOrEmpty(token); // Simplistic check for example purposes.
        }
    }
}


