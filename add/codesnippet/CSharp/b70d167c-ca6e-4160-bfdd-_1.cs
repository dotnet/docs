    internal class MyServiceCredentialsSecurityTokenManager : 
        ServiceCredentialsSecurityTokenManager
    {
        ServiceCredentials credentials;
        public MyServiceCredentialsSecurityTokenManager(ServiceCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator
            (SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            // Return your implementation of the SecurityTokenProvider based on the 
            // tokenRequirement argument.
            SecurityTokenAuthenticator result;
            if (tokenRequirement.TokenType == SecurityTokenTypes.UserName)
            {
                MessageDirection direction = tokenRequirement.GetProperty<MessageDirection>
                    (ServiceModelSecurityTokenRequirement.MessageDirectionProperty);
                if (direction == MessageDirection.Input)
                {
                    outOfBandTokenResolver = null;
                    result = new MySecurityTokenAuthenticator();
                }
                else
                {
                    result = base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
                }
            }
            else
            {
                result = base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
            }

            return result;
        }
    }