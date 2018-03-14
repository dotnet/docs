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
using System.Web;

namespace PassiveFlowIPSTS1
{
    /// <summary>
    /// Extends the Microsoft.IdentityModel.Services.SecurityTokenServiceConfiguration class to 
    /// be consumed by the CustomSecurityTokenService.
    /// </summary>
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        static readonly object syncRoot = new object();
        static string CustomSecurityTokenServiceConfigurationKey = "CustomSecurityTokenServiceConfigurationKey";

        public static CustomSecurityTokenServiceConfiguration Current
        {
            get
            {
                HttpApplicationState httpAppState = HttpContext.Current.Application;

                CustomSecurityTokenServiceConfiguration myConfiguration = httpAppState.Get( CustomSecurityTokenServiceConfigurationKey ) as CustomSecurityTokenServiceConfiguration;

                if ( myConfiguration != null )
                {
                    return myConfiguration;
                }

                lock ( syncRoot )
                {
                    myConfiguration = httpAppState.Get( CustomSecurityTokenServiceConfigurationKey ) as CustomSecurityTokenServiceConfiguration;

                    if ( myConfiguration == null )
                    {
                        myConfiguration = new CustomSecurityTokenServiceConfiguration();
                        httpAppState.Add( CustomSecurityTokenServiceConfigurationKey, myConfiguration );
                    }

                    return myConfiguration;
                }
            }
        }

        public CustomSecurityTokenServiceConfiguration()
            : base( "IPSTS1" )
        {
            SecurityTokenService = typeof(PassiveFlowIPSTS1.CustomSecurityTokenService);
        }
    }
}
