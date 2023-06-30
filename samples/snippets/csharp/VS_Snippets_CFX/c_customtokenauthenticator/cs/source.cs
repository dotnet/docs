//<snippet0>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace CustomTokenAuthenticator
{
    //<snippet1>
    internal class MySecurityTokenAuthenticator : SecurityTokenAuthenticator
    {
        protected override bool CanValidateTokenCore(SecurityToken token)
        {
            // Check that the incoming token is a username token type that
            // can be validated by this implementation.
            return (token is UserNameSecurityToken);
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy>
            ValidateTokenCore(SecurityToken token)
        {
            UserNameSecurityToken userNameToken = token as UserNameSecurityToken;

            // Validate the information contained in the username token. For demonstration
            // purposes, this code just checks that the user name matches the password.
            if (userNameToken.UserName != userNameToken.Password)
            {
                throw new SecurityTokenValidationException("Invalid user name or password");
            }

            // Create just one Claim instance for the username token - the name of the user.
            DefaultClaimSet userNameClaimSet = new DefaultClaimSet(
                ClaimSet.System,
                new Claim(ClaimTypes.Name, userNameToken.UserName, Rights.PossessProperty));
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>(1);
            policies.Add(new MyAuthorizationPolicy(userNameClaimSet));
            return policies.AsReadOnly();
        }
    }
    //</snippet1>

    //<snippet2>
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
    //</snippet2>

    //<snippet3>
    internal class MyAuthorizationPolicy : IAuthorizationPolicy
    {
        string id;
        ClaimSet tokenClaims;
        ClaimSet issuer;

        public MyAuthorizationPolicy(ClaimSet tokenClaims)
        {
            if (tokenClaims == null)
            {
                throw new ArgumentNullException("tokenClaims");
            }
            this.issuer = tokenClaims.Issuer;
            this.tokenClaims = tokenClaims;
            this.id = Guid.NewGuid().ToString();
        }

        public ClaimSet Issuer
        {
            get { return issuer; }
        }

        public string Id
        {
            get { return id; }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            // Add the token claim set to the evaluation context.
            evaluationContext.AddClaimSet(this, tokenClaims);

            // Return true if the policy evaluation is finished.
            return true;
        }
    }
    //</snippet3>
}
//</snippet0>
