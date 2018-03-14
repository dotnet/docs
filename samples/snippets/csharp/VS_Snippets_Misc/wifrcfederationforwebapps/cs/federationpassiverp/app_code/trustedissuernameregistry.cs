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
using System.IdentityModel.Tokens;

/// <summary>
/// Implements an IssuerNameRegistry that checks the given Issuer Token
/// to validated if it is trusted. If the token is trusted it returns a 
/// name for the issuer.
/// </summary>
public class TrustedIssuerNameRegistry : IssuerNameRegistry
{
    /// <summary>
    /// Checks if the given token's subject name is "CN=localhost". If 
    /// the subject name matches returns the BookPublisherSts name
    /// as the name of the issuer.
    /// </summary>
    /// <param name="securityToken">Issuer token.</param>
    /// <returns>Name of the Issuer.</returns>
    /// <exception cref="SecurityTokenException">The given issuer token is unknown.</exception>
    public override string GetIssuerName( SecurityToken securityToken )
    {
        X509SecurityToken x509Token = securityToken as X509SecurityToken;
        if ( x509Token != null )
        {
            //
            // WARNING: This demonstrates a simple implementation that just checks the 
            // certificate subject name. In production systems this might look up the 
            // certificate in a database(of trusted certificates) and might do additional 
            // validation like checking the certificate for revocation.
            //
            // DO NOT use this sample code 'as is' in production code.
            //
            if ( String.Equals( x509Token.Certificate.SubjectName.Name, "CN=localhost" ) )
            {
                return "FPSTS";
            }
        }

        throw new SecurityTokenException( "Untrusted issuer." );
    }
}
