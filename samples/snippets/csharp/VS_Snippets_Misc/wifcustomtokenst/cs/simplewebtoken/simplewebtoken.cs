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
//<Snippet2>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IdentityModel.Tokens;

namespace SimpleWebToken
{
    /// <summary>
    /// This class represents the token format for the SimpleWebToken.
    /// </summary>
    public class SimpleWebToken : SecurityToken
    {
        //<Snippet3>
        public static DateTime SwtBaseTime = new DateTime( 1970, 1, 1, 0, 0, 0, 0 ); // per SWT psec

        NameValueCollection _properties;
        //</Snippet3>
        string _serilaizedToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWebToken"/> class.
        /// This is internal contructor is only called from the <see cref="SimpleWebTokenHandler"/> when reading a token received from the wire.
        /// </summary>
        /// <param name="properties">The collection represents all the key value pairs in the token.</param>
        /// <param name="serializedToken">The serialized form of the token.</param>
        internal SimpleWebToken( NameValueCollection properties, string serializedToken )
            : this(properties)
        {
            _serilaizedToken = serializedToken;            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWebToken"/> class.
        /// </summary>
        /// <param name="properties">The collection represents all the key value pairs in the token.</param>
        public SimpleWebToken( NameValueCollection properties )
        {
            if ( properties == null )
            {
                throw new ArgumentNullException( "properties" );
            }

            _properties = properties;
        }

        //<Snippet4>
        /// <summary>
        /// Gets the Id of the token.
        /// </summary>
        /// <value>The Id of the token.</value>
        public override string Id
        {
            get 
            {
                return _properties[SimpleWebTokenConstants.Id];
            }
        }
        //</Snippet4>

        //<Snippet5>
        /// <summary>
        /// Gets the keys associated with this token.
        /// </summary>
        /// <value>The keys associated with this token.</value>
        public override ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get 
            { 
                return new ReadOnlyCollection<SecurityKey>( new List<SecurityKey>() ); 
            }
        }
        //</Snippet5>

        //<Snippet6>
        /// <summary>
        /// Gets the time from when the token is valid.
        /// </summary>
        /// <value>The time from when the token is valid.</value>
        public override DateTime ValidFrom
        {
            get 
            {
                string validFrom = _properties[SimpleWebTokenConstants.ValidFrom];
                return GetTimeAsDateTime( String.IsNullOrEmpty( validFrom ) ? "0" : validFrom );
            }
        }
        //</Snippet6>

        //<Snippet7>
        /// <summary>
        /// Gets the time when the token expires.
        /// </summary>
        /// <value>The time upto which the token is valid.</value>
        public override DateTime ValidTo
        {
            get
            {
                string expiryTime = _properties[SimpleWebTokenConstants.ExpiresOn];
                return GetTimeAsDateTime( String.IsNullOrEmpty( expiryTime ) ? "0" : expiryTime );
            }
        }
        //</Snippet7>

        /// <summary>
        /// Gets the Audience for the token.
        /// </summary>
        /// <value>The audience of the token.</value>
        public string Audience
        {
            get 
            {
                return _properties[SimpleWebTokenConstants.Audience];
            }
        }

        /// <summary>
        /// Gets the Issuer for the token.
        /// </summary>
        /// <value>The issuer for the token.</value>
        public string Issuer
        {
            get 
            { 
                return _properties[SimpleWebTokenConstants.Issuer]; 
            }
        }

        /// <summary>
        /// Gets the signature for the token.
        /// </summary>
        /// <value>The signature for the token.</value>
        public string Signature
        {
            get 
            { 
                return _properties[SimpleWebTokenConstants.Signature]; 
            }
        }

        /// <summary>
        /// Gets the serialized form of the token if the token was created from its serialized form by the token handler.
        /// </summary>
        /// <value>The serialized form of the token.</value>
        public string SerializedToken
        {
            get
            {
                return _serilaizedToken;
            }
        }

        /// <summary>
        /// Creates a copy of all key value pairs of the token.
        /// </summary>
        /// <returns>A copy of all the key value pairs in the token.</returns>
        public NameValueCollection GetAllProperties()
        {
            return new NameValueCollection( _properties );
        }

        //<Snippet8>
        /// <summary>
        /// Convert the time in seconds to a <see cref="DateTime"/> object based on the base time 
        /// defined by the Simple Web Token.
        /// </summary>
        /// <param name="expiryTime">The time in seconds.</param>
        /// <returns>The time as a <see cref="DateTime"/> object.</returns>
        protected virtual DateTime GetTimeAsDateTime( string expiryTime )
        {
            long totalSeconds = 0;
            if ( !long.TryParse( expiryTime, out totalSeconds ) )
            {
                throw new SecurityTokenException("Invalid expiry time. Expected the time to be in seconds passed from 1 January 1970.");
            }

            long maxSeconds = (long)( DateTime.MaxValue - SwtBaseTime ).TotalSeconds - 1;
            if ( totalSeconds > maxSeconds )
            {
                totalSeconds = maxSeconds;
            }

            return SwtBaseTime.AddSeconds( totalSeconds );
        } 
        //</Snippet8>
    }    
}

//</Snippet2>
