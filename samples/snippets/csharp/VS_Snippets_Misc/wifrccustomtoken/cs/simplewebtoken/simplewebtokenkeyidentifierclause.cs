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
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebToken
{
    public class SimpleWebTokenKeyIdentifierClause : SecurityKeyIdentifierClause
    {
        const string localId="SimpleWebToken";
        private string _audience;
                
        public SimpleWebTokenKeyIdentifierClause(string audience )
            :base (localId)
        {
            if (audience == null)
            {
                throw new ArgumentNullException("audience");
            }
            _audience = audience;
        }

        public string Audience
        {
            get
            {
                return _audience;
            }
        }

        public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
        {
            if (keyIdentifierClause is SimpleWebTokenKeyIdentifierClause)
            {
                return true;
            }

            return false;
        }
    }
}
