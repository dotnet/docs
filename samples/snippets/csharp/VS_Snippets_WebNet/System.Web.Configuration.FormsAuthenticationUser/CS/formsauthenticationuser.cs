using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Security;

namespace Samples.Aspnet.SystemWebConfiguration
{

// Accesses the
// System.Web.Configuration.FormsAuthenticationUser members
// selected by the user.
    class UsingFormsAuthenticationUser
    {
    
            public static void Main()
            {

            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnet");
            // Get the section.
            AuthenticationSection authenticationSection = 
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");
            // Get the users collection.
            FormsAuthenticationUserCollection formsAuthenticationUsers =
                authenticationSection.Forms.Credentials.Users;

            // </Snippet1>


            // <Snippet2>
           
            // </Snippet2>


            // <Snippet3>

            // Define the user name.
            string name = "userName";
            // Define the encrypted password.
            string password = 
                "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8";

            // Create a new FormsAuthenticationUser object.
            FormsAuthenticationUser newformsAuthenticationUser = 
                new FormsAuthenticationUser(name, password);

            // </Snippet3>

            // <Snippet4> 

            // Using the Password property.

            // Get current password.
            string currentPassword = 
                formsAuthenticationUsers[0].Password;

            // Set a SHA1 encrypted password.
            formsAuthenticationUsers[0].Password =
                "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8";

            // </Snippet4>

            // <Snippet5>

            // Using the Name property.

            // Get current name.
            string currentName = 
                formsAuthenticationUsers[0].Name;

            // Set a new name.
            formsAuthenticationUsers[0].Name = "userName";

            // </Snippet5>


        }

    }
  
} 