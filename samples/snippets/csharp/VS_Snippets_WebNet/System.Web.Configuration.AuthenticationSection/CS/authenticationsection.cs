using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

namespace Samples.AspNet.Configuration
{

    class UsingAuthenticationSection
    {
         public static void Main()
         {
 
            // <Snippet1>
            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the section.
            AuthenticationSection authenticationSection =
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // </Snippet1>


            // <Snippet2>
            AuthenticationSection newauthenticationSection = 
                new AuthenticationSection();

            // </Snippet2>


            // <Snippet3>
            // Get the current Passport property.
            PassportAuthentication currentPassport = 
                authenticationSection.Passport;

            // Get the Passport redirect URL.
            string passRedirectUrl = 
                currentPassport.RedirectUrl;

            // </Snippet3>


            // <Snippet4>
            // Get the current Mode property.
            AuthenticationMode currentMode = 
                authenticationSection.Mode;

            // Set the Mode property to Windows.
            authenticationSection.Mode = 
                AuthenticationMode.Windows;

            // </Snippet4>


            // <Snippet5>
            // Get the current Forms property.
            
            FormsAuthenticationConfiguration currentForms = 
                authenticationSection.Forms;

            // Get the Forms attributes.
            string name = currentForms.Name;
            string login = currentForms.LoginUrl;
            string path = currentForms.Path;
            HttpCookieMode cookieLess = currentForms.Cookieless;
            bool requireSSL = currentForms.RequireSSL;
            bool slidingExpiration = currentForms.SlidingExpiration;
            bool enableXappRedirect = currentForms.EnableCrossAppRedirects;

            TimeSpan timeout = currentForms.Timeout;
            FormsProtectionEnum protection = currentForms.Protection;
            string defaultUrl = currentForms.DefaultUrl;
            string domain = currentForms.Domain;

            // </Snippet5>

        }
   
    } 

} 

