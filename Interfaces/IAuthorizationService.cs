using System;

namespace MQTTBrokerProject.Interfaces
{
    public interface IAuthorizationService
    {
        /// <summary>
        /// Determines whether a user is authorized to perform a specified operation.
        /// </summary>
        /// <param name="username">The username of the user attempting the operation.</param>
        /// <param name="operation">The operation the user is attempting to perform.</param>
        /// <returns>true if the user is authorized to perform the operation; otherwise, false.</returns>
        bool IsAuthorized(string username, string operation);
    }
}
