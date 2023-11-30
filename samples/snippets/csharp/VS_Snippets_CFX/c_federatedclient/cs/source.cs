//<snippet0>
//<snippet1>
using System;
using System.ServiceModel;
using System.ServiceModel.Security;
namespace Samples
{
    //</snippet1>
    public sealed class IssuedTokenClientCredentialsConfiguration
    {
        //<snippet2>
        // This method configures the IssuedToken property of the Credentials property of a proxy/channel factory
        public static void ConfigureIssuedTokenClientCredentials(ChannelFactory cf, bool cacheTokens,
                                                                  TimeSpan tokenCacheTime, int renewalPercentage,
                                                                  SecurityKeyEntropyMode entropyMode
                                                                  )
        {
            if (cf == null)
            {
                throw new ArgumentNullException("cf");
            }
            // Set the CacheIssuedTokens property
            cf.Credentials.IssuedToken.CacheIssuedTokens = cacheTokens;

            // Set the MaxIssuedTokenCachingTime property
            cf.Credentials.IssuedToken.MaxIssuedTokenCachingTime = tokenCacheTime;

            // Set the IssuedTokenRenewalThresholdPercentage property
            cf.Credentials.IssuedToken.IssuedTokenRenewalThresholdPercentage = renewalPercentage;

            // Set the DefaultKeyEntropyMode property
            cf.Credentials.IssuedToken.DefaultKeyEntropyMode = entropyMode;
        }

        //</snippet2>

        // It is a good practice to create a private constructor for a class that only
        // defines static methods.
        private IssuedTokenClientCredentialsConfiguration() { }
    }
}
//</snippet0>
