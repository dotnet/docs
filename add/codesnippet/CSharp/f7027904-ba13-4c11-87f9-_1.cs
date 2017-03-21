        protected MyClientCredentials(MyClientCredentials other)
            : base(other)
        {
            this.clientEncryptingCert = other.clientEncryptingCert;
            this.clientSigningCert = other.clientSigningCert;
            this.serviceEncryptingCert = other.serviceEncryptingCert;
            this.serviceSigningCert = other.serviceSigningCert;
        }