// Snippet for U_SEIssuedTokenServiceCredential
// Type T:System.IdentityModel.Tokens.SamlSerializer
// Snippet used 0-1 cs 10
//
/* problem to fix, cannot assign different type
            ServiceCredentials creds = new ServiceCredentials();
            creds.IssuedTokenAuthentication.TrustedStoreLocation =  
                new X509Certificate2 ("mycert.cer");
 * how is TrustedStoreLocation used?
*/
//<Snippet0>
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace CS
{
    class MySamSerializer : SamlSerializer
    {}

    class Program
    {
        static void Main(string[] args)
        {
// <Snippet1>
            ServiceCredentials creds = new ServiceCredentials();
            creds.IssuedTokenAuthentication.SamlSerializer = new
                MySamSerializer();
// </Snippet1>

        }

        static void Main2()
        {
// Problem, cannot covert X509Certificate2 to StoreLocation
// <Snippet2>

            ServiceCredentials creds = new ServiceCredentials();
//            creds.IssuedTokenAuthentication.TrustedStoreLocation =
//                (StoreLocation) new X509Certificate2("mycert.cer");
// </Snippet2>   

        }
    }
}
//</Snippet0>