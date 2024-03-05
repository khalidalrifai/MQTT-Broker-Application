using System;

using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace MQTTBrokerProject.Interfaces
{
    public interface ITlsConfigurationService
    {
        /// <summary>
        /// Gets the TLS/SSL certificate for the MQTT broker.
        /// </summary>
        /// <returns>The X509Certificate used for TLS/SSL.</returns>
        X509Certificate2 GetBrokerCertificate();

        /// <summary>
        /// Validates the client certificate provided during the TLS/SSL handshake.
        /// </summary>
        /// <param name="clientCertificate">The client's X509Certificate.</param>
        /// <param name="chain">The certificate chain associated with the client certificate.</param>
        /// <param name="errors">Any errors encountered during the validation of the certificate.</param>
        /// <returns>True if the certificate is valid, otherwise false.</returns>
        bool ValidateClientCertificate(X509Certificate2 clientCertificate, X509Chain chain, SslPolicyErrors errors);
    }
}
