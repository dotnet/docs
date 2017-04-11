//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
// <snippet0>
using System;

using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

using System.IO;

using System.ServiceModel.Security;

using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// class that derives from SecurityTokenProvider and returns a SecurityToken representing a SAML assertion
    /// </summary>
    public class SamlSecurityTokenProvider : SecurityTokenProvider
    {
        /// <summary>
        /// The SAML assertion that the SamlSecurityTokenProvider will return as a SecurityToken
        /// </summary>
        SamlAssertion assertion;

        /// <summary>
        /// The proof token associated with the SAML assertion
        /// </summary>
        SecurityToken proofToken;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assertion">The SAML assertion that the SamlSecurityTokenProvider will return as a SecurityToken</param>
        /// <param name="proofToken">The proof token associated with the SAML assertion</param>
        public SamlSecurityTokenProvider(SamlAssertion assertion, SecurityToken proofToken )
        {
            this.assertion = assertion;
            this.proofToken = proofToken;
        }

        /// <summary>
        /// Creates the security token
        /// </summary>
        /// <param name="timeout">Maximum amount of time the method is supposed to take. Ignored in this implementation.</param>
        /// <returns>A SecurityToken corresponding the SAML assertion and proof key specified at construction time</returns>
        // <snippet1>
        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            // Create a SamlSecurityToken from the provided assertion
            SamlSecurityToken samlToken = new SamlSecurityToken(assertion);

            // Create a SecurityTokenSerializer that will be used to serialize the SamlSecurityToken
            WSSecurityTokenSerializer ser = new WSSecurityTokenSerializer();

            // Create a memory stream to write the serialized token into
            // Use an initial size of 64Kb
            MemoryStream s = new MemoryStream(UInt16.MaxValue);

            // Create an XmlWriter over the stream
            XmlWriter xw = XmlWriter.Create(s);
            
            // Write the SamlSecurityToken into the stream
            ser.WriteToken(xw, samlToken);

            // Seek back to the beginning of the stream
            s.Seek(0, SeekOrigin.Begin);

            // Load the serialized token into a DOM
            XmlDocument dom = new XmlDocument();
            dom.Load(s);
            
            // Create a KeyIdentifierClause for the SamlSecurityToken
            SamlAssertionKeyIdentifierClause samlKeyIdentifierClause = samlToken.CreateKeyIdentifierClause<SamlAssertionKeyIdentifierClause>();

            // Return a GenericXmlToken from the XML for the SamlSecurityToken, the proof token, the valid from 
            // and valid until times from the assertion and the key identifier clause created above            
            return new GenericXmlSecurityToken(dom.DocumentElement, proofToken, assertion.Conditions.NotBefore, assertion.Conditions.NotOnOrAfter, samlKeyIdentifierClause, samlKeyIdentifierClause, null);
        }
        // </snippet1>
    }
}
// </snippet0>