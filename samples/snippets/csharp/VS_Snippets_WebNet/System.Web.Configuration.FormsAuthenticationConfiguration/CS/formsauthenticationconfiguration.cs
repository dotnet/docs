using System;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Web;


namespace Samples.Aspnet.Configuration
{

    class UsingFormsAuthentication
    {

        public static void Main()
        {

            // <Snippet1>
            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

            // Get the external Authentication section.
            AuthenticationSection authenticationSection = 
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // Get the external Forms section .
            FormsAuthenticationConfiguration formsAuthentication =
                authenticationSection.Forms;

            //</Snippet1>


            // <Snippet2>
            // Create a new FormsAuthentication object.
            FormsAuthenticationConfiguration newformsAuthentication =
            new FormsAuthenticationConfiguration();

            // </Snippet2>



            // <Snippet3>
            // Get the current LoginUrl.
            string currentLoginUrl = formsAuthentication.LoginUrl;

            // Set the LoginUrl. 
            formsAuthentication.LoginUrl = "newLoginUrl";

            // </Snippet3>


            // <Snippet4>
            // Get current DefaultUrl.
            string currentDefaultUrl = 
                formsAuthentication.DefaultUrl;

            // Set current DefaultUrl.
            formsAuthentication.DefaultUrl = "newDefaultUrl";

            // </Snippet4>


            // <Snippet5>
            // Get current Cookieless.
            System.Web.HttpCookieMode currentCookieless = 
                formsAuthentication.Cookieless;
 
            // Set current Cookieless.
            formsAuthentication.Cookieless = 
                HttpCookieMode.AutoDetect;

            // </Snippet5>


            // <Snippet6>
            // Get the current Domain.
            string currentDomain = 
                formsAuthentication.Domain;

            // Set the current Domain
            formsAuthentication.Domain = "newDomain";


            // </Snippet6>


            // <Snippet7>
            // Get the current SlidingExpiration.
            bool currentSlidingExpiration = 
                formsAuthentication.SlidingExpiration;

            // Set the SlidingExpiration.
            formsAuthentication.SlidingExpiration = false;


            // </Snippet7>


            // <Snippet8>
            // Get the current EnableCrossAppRedirects.
            bool currentEnableCrossAppRedirects = 
                formsAuthentication.EnableCrossAppRedirects;

            // Set the EnableCrossAppRedirects.
            formsAuthentication.EnableCrossAppRedirects = false;


            // </Snippet8>


            // <Snippet9>
            // Get the current Path.
            string currentPath = formsAuthentication.Path;
            // Set the Path property.
            formsAuthentication.Path = "newPath";

            // </Snippet9>

            // <Snippet10>
            // Get the current Timeout.
            System.TimeSpan currentTimeout = 
                formsAuthentication.Timeout;
          
            // Set the Timeout.
            formsAuthentication.Timeout = 
                System.TimeSpan.FromMinutes(10);

            // </Snippet10>


            // <Snippet11>
            // Get the current Protection.
            FormsProtectionEnum currentProtection = 
                formsAuthentication.Protection;

            // Set the Protection property.
            formsAuthentication.Protection = 
                FormsProtectionEnum.All;

            // </Snippet11>


            // <Snippet12>
            // Get the current RequireSSL.
            bool currentRequireSSL = 
                formsAuthentication.RequireSSL;

            // Set the RequireSSL property value.
            formsAuthentication.RequireSSL = true;

            // </Snippet12>


            // <Snippet13>
            // Get the current Name property value.
            string currentName = formsAuthentication.Name;
            // Set the Name property value.
            formsAuthentication.Name = "newName";


            // </Snippet13>


            // <Snippet14>
            // Get the current Credentials.
            FormsAuthenticationCredentials currentCredentials = 
                formsAuthentication.Credentials;

            StringBuilder credentials = new StringBuilder();
            // Get all the credentials.
            for (System.Int32 i = 0; i < currentCredentials.Users.Count; i++)
            {
                credentials.Append("Name: " + 
                    currentCredentials.Users[i].Name + 
                    " Password: " + 
                    currentCredentials.Users[i].Password);
                credentials.Append(Environment.NewLine);
            }
            // </Snippet14>

        }
    }

} 

