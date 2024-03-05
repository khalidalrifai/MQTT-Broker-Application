using System;

namespace MQTTBrokerProject.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Validates the credentials for a given username and password.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the credentials are valid, otherwise false.</returns>
        bool ValidateCredentials(string username, string password);

        /// <summary>
        /// Validates the token for a given user.
        /// </summary>
        /// <param name="token">The token to validate.</param>
        /// <returns>True if the token is valid, otherwise false.</returns>
        bool ValidateToken(string token);
    }
}
