//<snippet0>
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;

namespace CustomProvider
{
    //<snippet1>
    internal class MySecurityTokenProvider : SecurityTokenProvider
    {
        X509Certificate2 certificate;

        public MySecurityTokenProvider(X509Certificate2 certificate)
        {
            this.certificate = certificate;
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            return new X509SecurityToken(certificate);
        }
    }
    //</snippet1>

    //<snippet2>
    internal class MyClientCredentialsSecurityTokenManager:ClientCredentialsSecurityTokenManager
    {
        ClientCredentials credentials;

        public MyClientCredentialsSecurityTokenManager(ClientCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(
            SecurityTokenRequirement tokenRequirement)
        {
            // Return your implementation of the SecurityTokenProvider based on the
            // tokenRequirement argument.
            SecurityTokenProvider result;
            if (tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate)
            {
                MessageDirection direction = tokenRequirement.GetProperty<MessageDirection>(
                    ServiceModelSecurityTokenRequirement.MessageDirectionProperty);
                if (direction == MessageDirection.Output)
                {
                    result = new MySecurityTokenProvider(credentials.ClientCertificate.Certificate);
                }
                else
                {
                    result = base.CreateSecurityTokenProvider(tokenRequirement);
                }
            }
            else
            {
                result = base.CreateSecurityTokenProvider(tokenRequirement);
            }

            return result;
        }
    }
    //</snippet2>
}
//</snippet0>
