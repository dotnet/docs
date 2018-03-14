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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;

namespace SimpleWebToken
{
    /// <summary>
    /// This class can parse and validate a Simple Web Token received on the incoming request.
    /// </summary>
    public class SimpleWebTokenHandler : SecurityTokenHandler
    {
        // <Snippet17>
        public const string SimpleWebTokenTypeUri = "http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0";
        // </Snippet17>
        
        const string Base64EncodingType = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";
        const string EncodingType = "EncodingType";       
        const string DefaultNameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        const string AcsNameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        const char ParameterSeparator = '&';
        const string BinarySecurityToken = "binarySecurityToken";
        const string ValueType    = "valueType";
                
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWebTokenHandler"/> class.
        /// </summary>
        public SimpleWebTokenHandler()
        {          
        }

        // <Snippet18>
        /// <summary>
        /// Gets the System.Type of the SecurityToken is supported by this handler.
        /// </summary>
        /// <value>The System.Type of the SecurityToken is supported by this handler.</value>
        public override Type TokenType
        {
            get
            {
                return typeof( SimpleWebToken );
            }
        }
        // </Snippet18>

        // <Snippet1>      
        /// <summary>
        /// Indicates whether the current XML element can be read as a token of the type handled by this instance.
        /// </summary>
        /// <param name="reader">An XML reader positioned at a start element. The reader should not be advanced.</param>
        /// <returns>True if the ReadToken method can the element.</returns>
        public override bool CanReadToken( XmlReader reader )
        {
            bool canRead = false;

            if ( reader != null )
            {
                if ( reader.IsStartElement( BinarySecurityToken)
                    && ( reader.GetAttribute( ValueType ) == SimpleWebTokenConstants.ValueTypeUri ) )
                {
                    canRead = true;
                }
            }

            return canRead;
        }
        // </Snippet1>

        // <Snippet2>
        /// <summary>
        /// Gets a value indicating whether this handler can validate tokens of type <see cref="SimpleWebToken"/>.
        /// </summary>     
        /// <value>True if this handler can validate the token of type <see cref="SimpleWebToken"/>.</value>
        public override bool CanValidateToken
        {
            get
            {
                return true;
            }
        }
        // </Snippet2>

        // <Snippet3>
        /// <summary>
        /// Gets a value indicating whether the SecurityTokenHandler can Serialize Tokens. Return true by default.
        /// </summary>
        /// <value>True is the handler can serialize tokens of type <see cref="SimpleWebToken"/>.</value>
        public override bool CanWriteToken
        {
            get
            {
                return true;
            }
        }
        // </Snippet3>
        // <Snippet4>
        public override SecurityToken CreateToken(SecurityTokenDescriptor tokenDescriptor)
        {
            if (tokenDescriptor == null)
            {
                throw new ArgumentNullException("tokenDescriptor");
            }

            NameValueCollection properties = new NameValueCollection();
            properties.Add(SimpleWebTokenConstants.Id, Guid.NewGuid().ToString());
            properties.Add(SimpleWebTokenConstants.Issuer, tokenDescriptor.TokenIssuerName);
            properties.Add(SimpleWebTokenConstants.Audience, tokenDescriptor.AppliesToAddress);
            properties.Add(SimpleWebTokenConstants.ExpiresOn, SecondsFromSwtBaseTime(tokenDescriptor.Lifetime.Expires));
            properties.Add(SimpleWebTokenConstants.ValidFrom, SecondsFromSwtBaseTime(tokenDescriptor.Lifetime.Created));

            foreach (Claim claim in tokenDescriptor.Subject.Claims)
            {
                properties.Add(claim.Type, claim.Value);
            }

            SimpleWebToken token = new SimpleWebToken(properties);
            return token;
        }
        // </Snippet4>

        private string SecondsFromSwtBaseTime(DateTime? time)
        {
            DateTime date = time ?? SimpleWebToken.SwtBaseTime;                
            TimeSpan t1 = date.Subtract(SimpleWebToken.SwtBaseTime);
            string seconds = ((long)t1.TotalSeconds).ToString();

            return seconds;
        }

        // <Snippet5>
        public override SecurityKeyIdentifierClause CreateSecurityTokenReference(SecurityToken token, bool attached)
        {
            return token.CreateKeyIdentifierClause<LocalIdKeyIdentifierClause>();           
        }
        // </Snippet5>

        // <Snippet6>
        /// <summary>
        /// Returns the simple web token's token type that is supported by this handler.
        /// </summary> 
        /// <returns>A list of supported token type identifiers.</returns>
        public override string[] GetTokenTypeIdentifiers()
        {
            return new string[] { SimpleWebTokenTypeUri };
        }
        // </Snippet6>

        // <Snippet7>
        /// <summary>
        /// Reads a serialized token and converts it into a <see cref="SecurityToken"/>.
        /// </summary>
        /// <param name="reader">An XML reader positioned at the token's start element.</param>
        /// <returns>The parsed form of the token.</returns>
        public override SecurityToken ReadToken( XmlReader reader )
        {
            if ( reader == null )
            {
                throw new ArgumentNullException( "reader" );
            }

            XmlDictionaryReader dictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader);

            byte[] binaryData;
            string encoding = dictionaryReader.GetAttribute( EncodingType );
            if ( encoding == null || encoding == Base64EncodingType )
            {
                dictionaryReader.Read();
                binaryData = dictionaryReader.ReadContentAsBase64();
            }
            else
            {
                throw new SecurityTokenException(
                    "Cannot read SecurityToken as its encoding is" + encoding + ". Expected a BinarySecurityToken with base64 encoding.");
            }
            
            string serializedToken = Encoding.UTF8.GetString(binaryData);

            return ReadSecurityTokenFromString(serializedToken);
        }
        // </Snippet7>

        // <Snippet8>
        /// <summary>
        /// Parse the string token and generates a <see cref="SecurityToken"/>.
        /// </summary>
        /// <param name="serializedToken">The serialized form of the token received.</param>
        /// <returns>The parsed form of the token.</returns>
        protected SecurityToken ReadSecurityTokenFromString( string serializedToken )
        {
            if (String.IsNullOrEmpty(serializedToken))
            {
                throw new ArgumentException("The parameter 'serializedToken' cannot be null or empty string.");
            }

            // Create a collection of SWT name value pairs
            NameValueCollection properties = ParseToken( serializedToken );
            SimpleWebToken swt = new SimpleWebToken( properties, serializedToken );

            return swt;
        }
        // </Snippet8>

        // <Snippet9>
        /// <summary>
        /// This method validates the Simple Web Token.
        /// </summary>
        /// <param name="token">A simple web token.</param>
        /// <returns>A Claims Collection which contains all the claims from the token.</returns>
        public override ReadOnlyCollection<ClaimsIdentity> ValidateToken(SecurityToken token)
        {
            if ( token == null )
            {
                throw new ArgumentNullException( "token" );
            }

            SimpleWebToken simpleWebToken = token as SimpleWebToken;
            if ( simpleWebToken == null )
            {
                throw new ArgumentException("The token provided must be of type SimpleWebToken.");                    
            }

            if ( DateTime.Compare( simpleWebToken.ValidTo.Add( Configuration.MaxClockSkew ), DateTime.UtcNow ) <= 0 )
            {
                throw new SecurityTokenExpiredException("The incoming token has expired. Get a new access token from the Authorization Server.");
            }

            ValidateSignature( simpleWebToken );
         
            ValidateAudience( simpleWebToken.Audience );
         
            ClaimsIdentity claimsIdentity = CreateClaims( simpleWebToken );
           
            if (this.Configuration.SaveBootstrapContext)
            {
                claimsIdentity.BootstrapContext = new BootstrapContext(simpleWebToken.SerializedToken);
            }

            List<ClaimsIdentity> claimCollection = new List<ClaimsIdentity>(new ClaimsIdentity[] { claimsIdentity });
            return claimCollection.AsReadOnly();
        }
        // </Snippet9>

        // <Snippet10>
        /// <summary>
        /// Serializes the given SecurityToken to the XmlWriter.
        /// </summary>
        /// <param name="writer">XmlWriter into which the token is serialized.</param>
        /// <param name="token">SecurityToken to be serialized.</param>
        public override void WriteToken( XmlWriter writer, SecurityToken token )
        {
            SimpleWebToken simpleWebToken = token as SimpleWebToken;
            if ( simpleWebToken == null )
            {
                throw new SecurityTokenException("The given token is not of the expected type 'SimpleWebToken'.");
            }

            string signedToken = null;

            if ( String.IsNullOrEmpty( simpleWebToken.SerializedToken ) )
            {
                StringBuilder strBuilder = new StringBuilder();

                bool skipDelimiter = true;
                NameValueCollection tokenProperties = simpleWebToken.GetAllProperties();

                // remove the signature if present
                if ( String.IsNullOrEmpty( tokenProperties[SimpleWebTokenConstants.Signature] ) )
                {
                    tokenProperties.Remove( SimpleWebTokenConstants.Signature );
                }

                foreach ( string key in tokenProperties.Keys )
                {
                    if ( tokenProperties[key] != null )
                    {
                        if ( !skipDelimiter )
                        {
                            strBuilder.Append( ParameterSeparator );
                        }

                        strBuilder.Append( String.Format(
                            CultureInfo.InvariantCulture,
                            "{0}={1}",
                            HttpUtility.UrlEncode( key ),
                            HttpUtility.UrlEncode( tokenProperties[key] ) ) );

                        skipDelimiter = false;
                    }
                }

                string serializedToken = strBuilder.ToString();

                SimpleWebTokenKeyIdentifierClause clause = new SimpleWebTokenKeyIdentifierClause(simpleWebToken.Audience);
                InMemorySymmetricSecurityKey securityKey = null;
                try
                {
                    securityKey = (InMemorySymmetricSecurityKey)this.Configuration.IssuerTokenResolver.ResolveSecurityKey(clause);
                }
                catch (InvalidOperationException)
                {
                    throw new SecurityTokenValidationException("A Symmetric key was not found for the given key identifier clause.");
                }
               
                // append the signature
                string signature = GenerateSignature( serializedToken, securityKey.GetSymmetricKey() );
                strBuilder.Append( String.Format(
                            CultureInfo.InvariantCulture,
                            "{0}{1}={2}",
                            ParameterSeparator,
                            HttpUtility.UrlEncode( SimpleWebTokenConstants.Signature ),
                            HttpUtility.UrlEncode( signature ) ) );

                signedToken = strBuilder.ToString();
            }
            else
            {
                // reuse the stored serialized token if present
                signedToken = simpleWebToken.SerializedToken;
            }

            string encodedToken = Convert.ToBase64String( Encoding.UTF8.GetBytes( signedToken ) );
            writer.WriteStartElement(BinarySecurityToken);
            writer.WriteAttributeString("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", token.Id);
            writer.WriteAttributeString( ValueType, SimpleWebTokenConstants.ValueTypeUri );
            writer.WriteAttributeString( EncodingType, Base64EncodingType );
            writer.WriteString( encodedToken );
            writer.WriteEndElement();
        }
        // </Snippet10>

        // <Snippet11>
        /// <summary>
        /// Generates an HMACSHA256 signature for a given string and key.
        /// </summary>
        /// <param name="unsignedToken">The token to be signed.</param>
        /// <param name="signingKey">The key used to generate the signature.</param>
        /// <returns>The generated signature.</returns>
        protected static string GenerateSignature(string unsignedToken, byte[] signingKey)
        {
            using (HMACSHA256 hmac = new HMACSHA256(signingKey))
            {
                byte[] signatureBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken));
                string signature = HttpUtility.UrlEncode(Convert.ToBase64String(signatureBytes));

                return signature;
            }
        }
        // </Snippet11>

        // <Snippet12>
        /// <summary>
        /// Validates the signature on the incoming token.
        /// </summary>
        /// <param name="simpleWebToken">The incoming <see cref="SimpleWebToken"/>.</param>
        protected virtual void ValidateSignature( SimpleWebToken simpleWebToken )
        {
            if ( simpleWebToken == null )
            {
                throw new ArgumentNullException( "simpleWebToken" );
            }

            if ( String.IsNullOrEmpty( simpleWebToken.SerializedToken ) || String.IsNullOrEmpty( simpleWebToken.Signature ) )
            {
                throw new SecurityTokenValidationException( "The token does not have a signature to verify" );
            }

            string serializedToken = simpleWebToken.SerializedToken;           
            string unsignedToken = null;

            // Find the last parameter. The signature must be last per SWT specification.
            int lastSeparator = serializedToken.LastIndexOf( ParameterSeparator );

            // Check whether the last parameter is an hmac.
            if ( lastSeparator > 0 )
            {
                string lastParamStart = ParameterSeparator + SimpleWebTokenConstants.Signature + "=";
                string lastParam = serializedToken.Substring( lastSeparator );

                // Strip the trailing hmac to obtain the original unsigned string for later hmac verification.               
                if ( lastParam.StartsWith( lastParamStart, StringComparison.Ordinal ) )
                {
                    unsignedToken = serializedToken.Substring( 0, lastSeparator );
                }
            }

            SimpleWebTokenKeyIdentifierClause clause = new SimpleWebTokenKeyIdentifierClause(simpleWebToken.Audience);
            InMemorySymmetricSecurityKey securityKey = null;
            try
            {
                securityKey = (InMemorySymmetricSecurityKey)this.Configuration.IssuerTokenResolver.ResolveSecurityKey(clause);
            }
            catch (InvalidOperationException)
            {
                throw new SecurityTokenValidationException( "A Symmetric key was not found for the given key identifier clause.");
            }

            string generatedSignature = GenerateSignature( unsignedToken, securityKey.GetSymmetricKey() );

            if ( string.CompareOrdinal( generatedSignature, simpleWebToken.Signature ) != 0 )
            {
                throw new SecurityTokenValidationException( "The signature on the incoming token is invalid.") ;
            }
        }
        // </Snippet12>

        // <Snippet13>
        /// <summary>
        /// Validates the audience of the incoming token with those specified in configuration.
        /// </summary>
        /// <param name="tokenAudience">The audience of the incoming token.</param>
        protected virtual void ValidateAudience( string tokenAudience )
        {
            if ( Configuration.AudienceRestriction.AudienceMode != AudienceUriMode.Never )
            {
                if ( String.IsNullOrEmpty( tokenAudience ) )
                {
                    throw new SecurityTokenValidationException("The incoming token does not have a valid audience Uri and the Audience Restriction is not set to 'None'.");
                }

                if ( Configuration.AudienceRestriction.AllowedAudienceUris.Count == 0 )
                {
                    throw new InvalidOperationException( " Audience Restriction is not set to 'None' but no valid audience URI's are configured." );
                }

                IList<Uri> allowedAudienceUris = Configuration.AudienceRestriction.AllowedAudienceUris;
                
                Uri audienceUri = null;

                Uri.TryCreate(tokenAudience, UriKind.RelativeOrAbsolute, out audienceUri);
                
                // Strip off any query string or fragment. 
                Uri audienceLeftPart;

                if ( audienceUri.IsAbsoluteUri )
                {
                    audienceLeftPart = new Uri( audienceUri.GetLeftPart( UriPartial.Path ) );
                }
                else
                {
                    Uri baseUri = new Uri( "http://www.example.com" );
                    Uri resolved = new Uri( baseUri, tokenAudience );
                    audienceLeftPart = baseUri.MakeRelativeUri( new Uri( resolved.GetLeftPart( UriPartial.Path ) ) );
                }

                if ( !allowedAudienceUris.Contains( audienceLeftPart ) )
                {
                    throw new AudienceUriValidationFailedException(
                            "The Audience Uri of the incoming token is not present in the list of permitted Audience Uri's.");
                }
            }
        }
        // </Snippet13>

        // <Snippet14>
        /// <summary>
        /// Parses the token into a collection.
        /// </summary>
        /// <param name="encodedToken">The serialized token.</param>
        /// <returns>A colleciton of all name-value pairs from the token.</returns>
        NameValueCollection ParseToken( string encodedToken )
        {
            if ( String.IsNullOrEmpty( encodedToken ) )
            {
                throw new ArgumentException( "The parameter 'encodedToken' cannot be null or empty string.");
            }

            NameValueCollection keyValuePairs = new NameValueCollection();
            foreach ( string nameValue in encodedToken.Split( ParameterSeparator ) )
            {
                string[] keyValueArray = nameValue.Split( '=' );

                if ( ( keyValueArray.Length < 2 ) || String.IsNullOrEmpty( keyValueArray[0] ) )
                {
                    throw new SecurityTokenException("The incoming token was not in an expected format.");
                }

                // Names must be decoded for the claim type case
                string key = HttpUtility.UrlDecode( keyValueArray[0].Trim() );

                // remove any unwanted "
                string value = HttpUtility.UrlDecode( keyValueArray[1].Trim().Trim( '"' ) ); 
                keyValuePairs.Add( key, value );
            }

            return keyValuePairs;
        }
        // </Snippet14>

        // <Snippet15>
        /// <summary>Creates <see cref="Claim"/>'s from the incoming token.
        /// </summary>
        /// <param name="simpleWebToken">The incoming <see cref="SimpleWebToken"/>.</param>
        /// <returns>A <see cref="ClaimsIdentity"/> created from the token.</returns>
        protected virtual ClaimsIdentity CreateClaims( SimpleWebToken simpleWebToken )
        {
            if ( simpleWebToken == null )
            {
                throw new ArgumentNullException( "simpleWebToken" );
            }

            NameValueCollection tokenProperties = simpleWebToken.GetAllProperties();
            if ( tokenProperties == null )
            {
                throw new SecurityTokenValidationException( "No claims can be created from this Simple Web Token." );
            }

            if ( Configuration.IssuerNameRegistry == null )
            {
                throw new InvalidOperationException( "The Configuration.IssuerNameRegistry property of this SecurityTokenHandler is set to null. Tokens cannot be validated in this state." );
            }

            string normalizedIssuer = Configuration.IssuerNameRegistry.GetIssuerName( simpleWebToken );

            ClaimsIdentity identity = new ClaimsIdentity(AuthenticationTypes.Federation);
            
            foreach ( string key in tokenProperties.Keys )
            {
                if ( ! IsReservedKeyName(key) &&  !string.IsNullOrEmpty( tokenProperties[key] ) )
                {
                    identity.AddClaim( new Claim( key, tokenProperties[key], ClaimValueTypes.String, normalizedIssuer ) );
                    if ( key == AcsNameClaimType )
                    {
                        // add a default name claim from the Name identifier claim.
                        identity.AddClaim( new Claim( DefaultNameClaimType, tokenProperties[key], ClaimValueTypes.String, normalizedIssuer ) );
                    }
                }
            }

            return identity;
        }
        // </Snippet15>

        // <Snippet16>
        /// <summary>
        /// Used to determine whether the parameter claim type is one of the reserved
        /// SimpleWebToken claim types: Audience, HMACSHA256, ExpiresOn or Issuer.
        /// </summary>
        /// <param name="keyName">The key name to be compared.</param>
        /// <returns>True if the key is a reserved key name.</returns>
        protected virtual bool IsReservedKeyName( string keyName )
        {
            if ( String.IsNullOrEmpty( keyName ) )
            {
                throw new ArgumentNullException( "keyName" );
            }

            switch ( keyName )
            {
                case SimpleWebTokenConstants.Audience:
                case SimpleWebTokenConstants.ExpiresOn:
                case SimpleWebTokenConstants.Id:
                case SimpleWebTokenConstants.Issuer:
                case SimpleWebTokenConstants.ValidFrom:
                case SimpleWebTokenConstants.Signature: return true;
                default: return false;
            }
        }
        // </Snippet16>
    }
}
