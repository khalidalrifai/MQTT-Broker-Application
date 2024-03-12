namespace MQTTBrokerProject.Configurations
{
    /// <summary>
    /// Configuration settings for the MQTT broker.
    /// </summary>
    public class BrokerConfig
    {
        // The host address where the MQTT broker is running.
        public string Host { get; set; }

        // The network port for non-TLS (unsecured) connections to the MQTT broker.
        public int Port { get; set; }

        // The network port for TLS (secured) connections to the MQTT broker.
        public int SecurePort { get; set; }

        // Optional username for broker authentication.
        public string Username { get; set; }

        // Optional password for broker authentication.
        public string Password { get; set; }

        // Indicates whether TLS is enabled for secure connections to the broker.
        public bool UseTls { get; set; }

        // TLS/SSL configuration settings for secure connections.
        public TlsSettings TlsSettings { get; set; }
    }

    /// <summary>
    /// Configuration for Transport Layer Security (TLS) settings.
    /// </summary>
    public class TlsSettings
    {
        // The file path to the TLS certificate used for secure connections.
        public string CertificatePath { get; set; }

        // The password for accessing the TLS certificate, if required.
        public string CertificatePassword { get; set; }

        // Indicates whether the broker should validate the TLS certificate. Recommended to be true for production.
        public bool ValidateCertificate { get; set; } = true;

        // Allows connection to the broker with untrusted certificates. Use with caution, typically for development only.
        public bool AllowUntrustedCertificates { get; set; } = false;

        // Determines whether to ignore certificate chain errors. Not recommended for production environments.
        public bool IgnoreCertificateChainErrors { get; set; } = false;

        // Determines whether to ignore certificate revocation errors. Not recommended for production use.
        public bool IgnoreCertificateRevocationErrors { get; set; } = false;
    }
}
