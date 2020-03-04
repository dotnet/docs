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

//<Snippet1>
using System;
using System.IdentityModel.Tokens;

namespace System.IdentityModel.Samples
{
    /// <summary>
    /// This class verifies that the issuer is trusted, and provides the issuer name.
    /// </summary>
    public class TrustedIssuerNameRegistry : IssuerNameRegistry
    {
        // <Snippet2>
        /// <summary>
        /// Gets the issuer name of the given security token,
        /// if it is the X509SecurityToken of 'localhost'.
        /// </summary>
        /// <param name="securityToken">The issuer's security token</param>
        /// <returns>A string that represents the issuer name</returns>
        /// <exception cref="SecurityTokenException">If the issuer is not trusted.</exception>
        public override string GetIssuerName(SecurityToken securityToken)
        {
            X509SecurityToken x509Token = securityToken as X509SecurityToken;
            if (x509Token != null)
            {
                if (String.Equals(x509Token.Certificate.SubjectName.Name, "CN=localhost"))
                {
                    return x509Token.Certificate.SubjectName.Name;
                }
            }

            throw new SecurityTokenException("Untrusted issuer.");
        }
        //</Snippet2>
    }
}
//</Snippet1>