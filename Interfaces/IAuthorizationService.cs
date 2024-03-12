using System;

namespace MQTTBrokerProject.Interfaces
{
    /// <summary>
    /// Provides authorization functionalities, determining if users are allowed to perform specific operations.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Checks if the specified user is authorized to carry out a certain operation.
        /// </summary>
        /// <param name="username">Username of the user attempting the operation.</param>
        /// <param name="operation">The operation to be performed.</param>
        /// <returns>True if the user is authorized; otherwise, false.</returns>
        bool IsAuthorized(string username, string operation);
    }
}
