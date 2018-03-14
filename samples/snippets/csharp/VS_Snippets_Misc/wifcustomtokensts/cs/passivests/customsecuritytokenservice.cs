//-----------------------------------------------------------------------------
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//-----------------------------------------------------------------------------

// <Snippet3>
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace PassiveSTS
{
    /// <summary>
    /// Overrides the SecurityTokenService class to provide
    /// the relying party related information, such as encryption credentials to encrypt the issued
    /// token, signing credentials to sign the issued token, claims that the STS wants to issue for a 
    /// certain token request, as well as the claim types that this STS is capable
    /// of issuing.
    /// </summary>
    public class CustomSecurityTokenService : SecurityTokenService
    {
        // <Snippet4>
        // Certificate Constants
        private const string SIGNING_CERTIFICATE_NAME = "CN=localhost";
        private const string ENCRYPTING_CERTIFICATE_NAME = "CN=localhost";

        private SigningCredentials _signingCreds;
        private EncryptingCredentials _encryptingCreds;
        // Used for validating applies to address, set to URI used in RP app of application, could also have been done via config
        private string _addressExpected = "http://localhost:19851/";
        // </Snippet4>
        public CustomSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
            // Setup the certificate our STS is going to use to sign the issued tokens
            _signingCreds = new X509SigningCredentials(CertificateUtil.GetCertificate(StoreName.My, StoreLocation.LocalMachine, SIGNING_CERTIFICATE_NAME));

            // Note: In this sample app only a si   ngle RP identity is shown, which is localhost, and the certificate of that RP is 
            // populated as _encryptingCreds
            // If you have multiple RPs for the STS you would select the certificate that is specific to 
            // the RP that requests the token and then use that for _encryptingCreds
            _encryptingCreds = new X509EncryptingCredentials(CertificateUtil.GetCertificate(StoreName.My, StoreLocation.LocalMachine, ENCRYPTING_CERTIFICATE_NAME));
        }

        // <Snippet5>
        /// <summary>
        /// This method returns the configuration for the token issuance request. The configuration
        /// is represented by the Scope class. In our case, we are only capable of issuing a token to a
        /// single RP identity represented by the _encryptingCreds field.
        /// </summary>
        /// <param name="principal">The caller's principal</param>
        /// <param name="request">The incoming RST</param>
        /// <returns></returns>
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            // Validate the AppliesTo address
            ValidateAppliesTo( request.AppliesTo );

            // Create the scope using the request AppliesTo address and the RP identity
            Scope scope = new Scope( request.AppliesTo.Uri.AbsoluteUri, _signingCreds );

            if (Uri.IsWellFormedUriString(request.ReplyTo, UriKind.Absolute))
            {
                if (request.AppliesTo.Uri.Host != new Uri(request.ReplyTo).Host)
                    scope.ReplyToAddress = request.AppliesTo.Uri.AbsoluteUri;
                else
                    scope.ReplyToAddress = request.ReplyTo;
            }
            else
            {
                Uri resultUri = null;
                if (Uri.TryCreate(request.AppliesTo.Uri, request.ReplyTo, out resultUri))
                    scope.ReplyToAddress = resultUri.AbsoluteUri;
                else
                    scope.ReplyToAddress = request.AppliesTo.Uri.ToString() ;
            }

            // Note: In this sample app only a single RP identity is shown, which is localhost, and the certificate of that RP is 
            // populated as _encryptingCreds
            // If you have multiple RPs for the STS you would select the certificate that is specific to 
            // the RP that requests the token and then use that for _encryptingCreds
            scope.EncryptingCredentials = _encryptingCreds;

            return scope;
        }
        // </Snippet5>
        // <Snippet6>
        /// <summary>
        /// This method returns the content of the issued token. The content is represented as a set of
        /// IClaimIdentity intances, each instance corresponds to a single issued token. Currently, the Windows Identity Foundation only
        /// supports a single token issuance, so the returned collection must always contain only a single instance.
        /// </summary>
        /// <param name="scope">The scope that was previously returned by GetScope method</param>
        /// <param name="principal">The caller's principal</param>
        /// <param name="request">The incoming RST, we don't use this in our implementation</param>
        /// <returns></returns>
        protected override ClaimsIdentity GetOutputClaimsIdentity( ClaimsPrincipal principal, RequestSecurityToken request, Scope scope )
        {
            //
            // Return a default claim set which contains a custom decision claim
            // Here you can actually examine the user by looking at the IClaimsPrincipal and 
            // return the right decision based on that. 
            //
            ClaimsIdentity outgoingIdentity = new ClaimsIdentity();
            outgoingIdentity.AddClaims(principal.Claims);

            return outgoingIdentity;
        }
        // </Snippet6>
        // <Snippet7>
        /// <summary>
        /// Validates the appliesTo and throws an exception if the appliesTo is null or appliesTo contains some unexpected address.
        /// </summary>
        /// <param name="appliesTo">The AppliesTo parameter in the request that came in (RST)</param>
        /// <returns></returns>
        void ValidateAppliesTo(EndpointReference appliesTo)
        {
            if (appliesTo == null)
            {
                throw new InvalidRequestException("The appliesTo is null.");
            }

            if (!appliesTo.Uri.Equals(new Uri(_addressExpected)))
            {
                throw new InvalidRequestException(String.Format("The relying party address is not valid. Expected value is {0}, the actual value is {1}.", _addressExpected, appliesTo.Uri.AbsoluteUri));
            }
        }

        //</Snippet7>
       
    }
}
// </Snippet3>