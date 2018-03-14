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

        // Claims that are issued by this FP STS and that are expected by it's RP
        private const string FPSTS_UPN_CLAIM = "http://WindowsIdentityFoundationSamples/FPSTS/2008/myUPNName";
        private const string FPSTS_AGE_RANGE_CLAIM = "http://WindowsIdentityFoundationSamples/FPSTS/2008/myAgeRangeClaim";
        private const string FPSTS_CITY_CLAIM = "http://WindowsIdentityFoundationSamples/FPSTS/2008/myCityClaim";
        private const string FPSTS_IDENTIFIER_CLAIM = "http://WindowsIdentityFoundationSamples/FPSTS/2008/IdentityProviderIdentifier";

        private const string FPSTS_ID_CLAIM_FROM_IPSTS1 = "http://WindowsIdentityFoundationSamples/FPSTS/IPSTS1/2008/myID";
        private const string FPSTS_AGE_CLAIM_FROM_IPSTS1 = "http://WindowsIdentityFoundationSamples/FPSTS/IPSTS1/2008/myAgeClaim";
        private const string FPSTS_ID_CLAIM_FROM_IPSTS2 = "http://WindowsIdentityFoundationSamples/FPSTS/IPSTS2/2008/myID";
        private const string FPSTS_ZIPCODE_CLAIM_FROM_IPSTS2 = "http://WindowsIdentityFoundationSamples/FPSTS/IPSTS2/2008/myZipcodeClaim";

        // Claims that are expected from IP STS1
        private const string IPSTS1_ID_CLAIM = "http://WindowsIdentityFoundationSamples/IPSTS1/2008/myID";
        private const string IPSTS1_AGE_CLAIM = "http://WindowsIdentityFoundationSamples/IPSTS1/2008/myAgeClaim";
        private const string IPSTS1_IDENTIFIER_CLAIM = "http://WindowsIdentityFoundationSamples/IPSTS1/2008/IdentityProviderIdentifier";

        // Claims that are expected from IP STS2
        private const string IPSTS2_ID_CLAIM = "http://WindowsIdentityFoundationSamples/IPSTS2/2008/myID";
        private const string IPSTS2_ZIPCODE_CLAIM = "http://WindowsIdentityFoundationSamples/IPSTS2/2008/myZipcodeClaim";
        private const string IPSTS2_IDENTIFIER_CLAIM = "http://WindowsIdentityFoundationSamples/IPSTS2/2008/IdentityProviderIdentifier";

        private SigningCredentials _signingCreds;
        private EncryptingCredentials _encryptingCreds;
        private string _addressExpected = "https://localhost/PassiveRP/Default.aspx";

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
            Scope scope = new Scope(request.AppliesTo.Uri.AbsoluteUri, _signingCreds);

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
                    scope.ReplyToAddress = request.AppliesTo.Uri.ToString();
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
            ClaimsIdentity incomingIdentity = principal.Identities[0];

            // Do the claim transform based on who the IP STS is and the claims issued by those
            // Transform the incoming claims to appropriate outgoing claims
            // Add the claims issued by IP STSes for illustrative purposes, ONLY the expected claims
            // are being added to the list and others are disregarded

            bool type1, type2;
            type1 = type2 = false;

            foreach (Claim c in incomingIdentity.Claims)
            {
                if (c.Type.Equals(IPSTS1_IDENTIFIER_CLAIM))
                {
                    type1 = true;
                    break;
                }
                if (c.Type.Equals(IPSTS2_IDENTIFIER_CLAIM))
                {
                    type2 = true;
                    break;
                }
            }

            if (type1)
            {
                TransformIPSTS1Claims(incomingIdentity, outgoingIdentity);
            }

            if (type2)
            {
                TransformIPSTS2Claims(incomingIdentity, outgoingIdentity);
            }

            return outgoingIdentity;
        }

        private void TransformIPSTS1Claims(ClaimsIdentity incomingIdentity, ClaimsIdentity outgoingIdentity)
        {
            foreach (Claim claim in incomingIdentity.Claims)
            {
                // If myID claim exists, transform that to be a UPN claim
                if (claim.Type.Equals(IPSTS1_ID_CLAIM))
                {
                    // add the IPSTS claim as well for illustrative purposes
                    outgoingIdentity.AddClaim(new Claim(FPSTS_ID_CLAIM_FROM_IPSTS1, claim.Value, claim.ValueType));

                    // value transform
                    outgoingIdentity.AddClaim(new Claim(FPSTS_UPN_CLAIM, claim.Value + "@contoso.com", ClaimValueTypes.String));
                }
                else if (claim.Type.Equals(IPSTS1_AGE_CLAIM))
                {
                    // add the IPSTS claim as well for illustrative purposes
                    outgoingIdentity.AddClaim(new Claim(FPSTS_AGE_CLAIM_FROM_IPSTS1, claim.Value, claim.ValueType));

                    // new claim type
                    if (Convert.ToInt32(claim.Value) >= 21)
                        outgoingIdentity.AddClaim(new Claim(FPSTS_AGE_RANGE_CLAIM, "Age is >= 21", ClaimValueTypes.String));
                    else
                        outgoingIdentity.AddClaim(new Claim(FPSTS_AGE_RANGE_CLAIM, "Age is less than 21", ClaimValueTypes.String));

                }
                else if (claim.Type.Equals(IPSTS1_IDENTIFIER_CLAIM))
                {
                    // add the IPSTS claim as well for illustrative purposes
                    outgoingIdentity.AddClaim(new Claim(FPSTS_IDENTIFIER_CLAIM, claim.Value, claim.ValueType));

                    // No transformation is performed for this identifier
                }
                else if (claim.Type.Equals(ClaimTypes.Name))
                {
                    // add the name claim received from IPSTS
                    outgoingIdentity.AddClaim(new Claim(ClaimTypes.Name, claim.Value, claim.ValueType));
                }
            }
        }

        private void TransformIPSTS2Claims(ClaimsIdentity incomingIdentity, ClaimsIdentity outgoingIdentity)
        {
            foreach (Claim claim in incomingIdentity.Claims)
            {
                // If IPSTS2/myID claim exists transform that to be a UPN format
                if (claim.Type.Equals(IPSTS2_ID_CLAIM))
                {
                    // add the IPSTS claim as well for illustrative purposes
                    outgoingIdentity.AddClaim(new Claim(FPSTS_ID_CLAIM_FROM_IPSTS2, claim.Value, claim.ValueType));

                    // value transform
                    outgoingIdentity.AddClaim(new Claim(FPSTS_UPN_CLAIM, claim.Value + "@fabrikam.com", ClaimValueTypes.String));
                }
                else if (claim.Type.Equals(IPSTS2_ZIPCODE_CLAIM))
                {
                    // add the IPSTS claim as well for illustrative purposes
                    outgoingIdentity.AddClaim(new Claim(FPSTS_ZIPCODE_CLAIM_FROM_IPSTS2, claim.Value, claim.ValueType));

                    // new claim type
                    outgoingIdentity.AddClaim(new Claim(FPSTS_CITY_CLAIM, "Redmond WA", ClaimValueTypes.String));
                }
                else if (claim.Type.Equals(IPSTS2_IDENTIFIER_CLAIM))
                {
                    // add the IPSTS claim as well for illustrative purposes
                    outgoingIdentity.AddClaim(new Claim(FPSTS_IDENTIFIER_CLAIM, claim.Value, claim.ValueType));

                    // no transformation is performed here
                }
                else if (claim.Type.Equals(ClaimTypes.Name))
                {
                    // add the name claim received from IPSTS
                    outgoingIdentity.AddClaim(new Claim(ClaimTypes.Name, claim.Value, claim.ValueType));
                }
            }
        }

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
    }

}
