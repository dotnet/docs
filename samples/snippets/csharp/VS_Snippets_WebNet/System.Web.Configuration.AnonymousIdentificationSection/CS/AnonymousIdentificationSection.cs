// <Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using System.Configuration;

namespace Samples.AspNet
{
    class UsingAnonymousIdentificationSection
    {
        static void Main(string[] args)
        {

            // <Snippet2>
            // Get the applicaqtion configuration.
            Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
               "/aspnetTest");

            // Get the section.
            AnonymousIdentificationSection anonymousIdentificationSection = 
                (AnonymousIdentificationSection)configuration.GetSection(
                "system.web/anonymousIdentification");
            // </Snippet2>


            // <Snippet3>
            // Get Cookieless.
            System.Web.HttpCookieMode cookieless =
                anonymousIdentificationSection.Cookieless;
            Console.WriteLine("Cookieless: {0}",
                      cookieless);
            // </Snippet3>

            // <Snippet4>
            // Get CookieName.
            string cookieName =
                anonymousIdentificationSection.CookieName;
            Console.WriteLine("Cookie name: {0}",
                cookieName);
            // </Snippet4>

            // <Snippet5>
            // Get CookiePath.
            string cookiePath = 
                anonymousIdentificationSection.CookiePath;
            Console.WriteLine("Cookie path: {0}", cookiePath);
            // </Snippet5>

            // <Snippet6>
            // Get CookieProtection.
            System.Web.Security.CookieProtection cookieProtection =
                anonymousIdentificationSection.CookieProtection;
            Console.WriteLine("Cookie protection: {0}",
                       cookieProtection);
            // </Snippet6>

            // <Snippet7>
            // Get CookieRequireSSL.
            bool cookieRequireSSL = 
                anonymousIdentificationSection.CookieRequireSSL;
            Console.WriteLine("Cookie require SSL: {0}", 
                cookieRequireSSL.ToString());
            // </Snippet7>

            // <Snippet8>
            // Get CookieSlidingExpiration.
            bool cookieSlidingExpiration = 
                anonymousIdentificationSection.CookieSlidingExpiration;
            Console.WriteLine("Cookie sliding expiration: {0}",
                cookieSlidingExpiration.ToString());
            // </Snippet8>

            // <Snippet9>
            // Get CookieTimeout.
            TimeSpan cookieTimeout =
                anonymousIdentificationSection.CookieTimeout;
            Console.WriteLine("Cookie timeout: {0}",
                cookieTimeout.ToString());
            // </Snippet9>


            // <Snippet10>
            // Get Domain.
            string domain =
                anonymousIdentificationSection.Domain;
            Console.WriteLine("Anonymous identification domain: {0}",
                domain);
            // </Snippet10>

            // <Snippet11>
            // Get Enabled.
            bool aIdEnabled =
                anonymousIdentificationSection.Enabled;
         
            Console.WriteLine("Anonymous identification enabled: {0}",
                aIdEnabled.ToString());
            // </Snippet11>

           
        }

    }
}
// </Snippet1>