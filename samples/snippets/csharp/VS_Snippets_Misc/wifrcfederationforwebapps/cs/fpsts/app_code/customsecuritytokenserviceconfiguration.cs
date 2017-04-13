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

using System.IdentityModel.Configuration;

namespace PassiveFlowSTS
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        public CustomSecurityTokenServiceConfiguration()
            : base(null)
        {
            TokenIssuerName = "PassiveFlowSTS";
            SecurityTokenService = typeof( PassiveFlowSTS.CustomSecurityTokenService );
        }
    }
}
