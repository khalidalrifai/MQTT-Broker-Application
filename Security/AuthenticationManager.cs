using System;
using System.Collections.Generic;
using MQTTBrokerProject.Interfaces;

namespace MQTTBrokerProject.Security
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly Dictionary<string, string> _userCredentials;

        public AuthenticationManager()
        {
            // Example user credentials; in a real application, consider using a more secure method.
            _userCredentials = new Dictionary<string, string>
            {
                { "user1", "password1" },
                { "user2", "password2" }
                // Add more as needed.
            };
        }

        public bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return _userCredentials.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        public bool ValidateToken(string token)
        {
            // Implement token validation logic here if using token-based authentication.
            return false; // Placeholder implementation.
        }
    }
}


