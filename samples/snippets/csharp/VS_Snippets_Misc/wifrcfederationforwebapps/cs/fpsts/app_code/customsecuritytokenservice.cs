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


using System;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace PassiveFlowSTS
{
    /// <summary>
    /// Extends the Microsoft.IdentityModel.Services.SecurityTokenService class to provide
    /// the relying party related information, such as encryption credentials to encrypt the issued
    /// token, signing credentials to sign the issued token, claims that STS wants to issue for a 
    /// certain token request, as well as the claim types that this STS is capable
    /// of issuing.
    /// </summary>
    public class CustomSecurityTokenService : SecurityTokenService
    {
        // Certificate Constants
        private const string SIGNING_CERTIFICATE_NAME = "CN=localhost";
        private const string ENCRYPTING_CERTIFICATE_NAME = "CN=localhost";

        private SigningCredentials _signingCreds;
        private EncryptingCredentials _encryptingCreds;
        private string _addressExpected = "http://localhost:2000/FederationPassiveRP/Default.aspx";
        // Custom Claims that this IP STS is capable of issuing
        private const string IDENTITY_PROVIDER_CLAIM = "http://FederationForWebApps/IdentityProviders";


        public CustomSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
            // Setup the certificate our STS is going to use to sign the issued tokens
            _signingCreds = new X509SigningCredentials(CertificateUtil.GetCertificate(StoreName.My, StoreLocation.LocalMachine, SIGNING_CERTIFICATE_NAME));

            // Note: In this sample app only a single RP identity is shown, which is localhost, and the certificate of that RP is 
            // populated as _encryptingCreds
            // If you have multiple RPs for the STS you would select the certificate that is specific to 
            // the RP that requests the token and then use that for _encryptingCreds
            _encryptingCreds = new X509EncryptingCredentials(CertificateUtil.GetCertificate(StoreName.My, StoreLocation.LocalMachine, ENCRYPTING_CERTIFICATE_NAME));
        }


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
            // First thing to do is verify that the caller is the expected one
            ValidateAppliesTo(request.AppliesTo);

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

        /// <summary>
        /// This method returns the content of the issued token. The content is represented as a set of
        /// IClaimIdentity instances, each instance corresponds to a single issued token. Currently, the Windows Identity Foundation
        /// supports a single token issuance, so the returned collection must always contain only a single instance.
        /// </summary>
        /// <param name="scope">The scope that was previously returned by GetScope method</param>
        /// <param name="principal">The caller's principal</param>
        /// <param name="request">The incoming RST, we don't use this in our implementation</param>
        /// <returns></returns>
        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            ClaimsIdentity outgoingIdentity = new ClaimsIdentity();
            foreach (Claim c in principal.Claims)
            {
                if (String.Compare(c.Type, IDENTITY_PROVIDER_CLAIM) == 0)
                {
                    outgoingIdentity.AddClaim(new Claim(c.Type, "fpsts." + c.Value));
                }
                else
                {
                    outgoingIdentity.AddClaim(new Claim(c.Type, c.Value, c.ValueType, "FPSTS", c.OriginalIssuer));
                }
            }

            Claim nameClaim = principal.FindFirst(ClaimTypes.Name);
            string emailAddress = nameClaim.Value + "@fpsts.com";
            Claim emailClaim = new Claim(ClaimTypes.Email, emailAddress, ClaimValueTypes.String, "FPSTS");
            outgoingIdentity.AddClaim(emailClaim);

            return outgoingIdentity;
        }

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
    }

}
