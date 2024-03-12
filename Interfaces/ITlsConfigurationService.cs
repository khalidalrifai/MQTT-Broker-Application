using System;

using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace MQTTBrokerProject.Interfaces
{
    /// <summary>
    /// Manages TLS/SSL configuration for secure MQTT communication, including certificate handling and validation.
    /// </summary>
    public interface ITlsConfigurationService
    {
        /// <summary>
        /// Retrieves the TLS/SSL certificate used by the MQTT broker.
        /// </summary>
        /// <returns>The X509Certificate used for secure communication.</returns>
        X509Certificate2 GetBrokerCertificate();

        /// <summary>
        /// Validates a client's certificate presented during the TLS/SSL handshake.
        /// </summary>
        /// <param name="clientCertificate">The client's X509Certificate.</param>
        /// <param name="chain">The certificate chain associated with the client certificate.</param>
        /// <param name="errors">Policy errors encountered during the certificate validation process.</param>
        /// <returns>True if the certificate is valid and trusted; otherwise, false.</returns>
        bool ValidateClientCertificate(X509Certificate2 clientCertificate, X509Chain chain, SslPolicyErrors errors);
    }
}
