using MQTTBrokerProject.Interfaces;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MQTTBrokerProject.Services
{
    public class TlsConfigurationService : ITlsConfigurationService
    {
        public X509Certificate2 GetBrokerCertificate()
        {
            // Load and return the broker's TLS certificate.
            // In a real application, ensure your certificate is securely stored and appropriately loaded.
            // Example: return new X509Certificate2("path/to/your/certificate.pfx", "yourPassword");
            throw new NotImplementedException();
        }

        public bool ValidateClientCertificate(X509Certificate2 clientCertificate, X509Chain chain, SslPolicyErrors errors)
        {
            // Implement your certificate validation logic here.
            // This example assumes all client certificates are valid if there are no SSL policy errors.
            return errors == SslPolicyErrors.None;
        }
    }
}


