    internal class MyServiceCredentialsSecurityTokenManager : 
        ServiceCredentialsSecurityTokenManager
    {
        MyServiceCredentials credentials;

        public MyServiceCredentialsSecurityTokenManager(
            MyServiceCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(
            SecurityTokenRequirement requirement)
        {
            SecurityTokenProvider result = null;
            if (requirement.TokenType == SecurityTokenTypes.X509Certificate)
            {
                MessageDirection direction = requirement.
                    GetProperty<MessageDirection>(
                    ServiceModelSecurityTokenRequirement.
                    MessageDirectionProperty);
                if (direction == MessageDirection.Input)
                {
                    if (requirement.KeyUsage == SecurityKeyUsage.Exchange)
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ServiceEncryptingCertificate);
                    }
                    else
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ClientSigningCertificate);
                    }
                }
                else
                {
                    if (requirement.KeyUsage == SecurityKeyUsage.Signature)
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ServiceSigningCertificate);
                    }
                    else
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ClientEncryptingCertificate);
                    }
                }
            }
            else
            {
                result = base.CreateSecurityTokenProvider(requirement);
            }
            return result;
        }
    }