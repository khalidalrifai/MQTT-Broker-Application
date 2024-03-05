namespace MQTTBrokerProject.Configurations
{
    public class BrokerConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int SecurePort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseTls { get; set; }
        public TlsSettings TlsSettings { get; set; }
    }

    public class TlsSettings
    {
        public string CertificatePath { get; set; }
        public string CertificatePassword { get; set; }
        public bool ValidateCertificate { get; set; } = true;
        public bool AllowUntrustedCertificates { get; set; } = false;
        public bool IgnoreCertificateChainErrors { get; set; } = false;
        public bool IgnoreCertificateRevocationErrors { get; set; } = false;
    }
}
