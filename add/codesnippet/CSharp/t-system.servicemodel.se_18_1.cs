    internal class MyServiceCredentialsSecurityTokenManager : 
        ServiceCredentialsSecurityTokenManager
    {
        MyServiceCredentials credentials;

        public MyServiceCredentialsSecurityTokenManager(MyServiceCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            // Return your implementation of SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            // Return your implementation of SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            // Return your implementation of SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenSerializer(version);
        }
    }