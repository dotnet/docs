using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.AspNet
{

    class UsingFormsAuthenticationCredentials
    {

        public static void Main()
        {

            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

            // Get the authentication section.
            AuthenticationSection authenticationSection = 
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // Get the forms credentials collection .
            FormsAuthenticationCredentials formsAuthenticationCredentials =
                authenticationSection.Forms.Credentials;

            // </Snippet1>

            // <Snippet2>
            // Create a new FormsAuthenticationCredentials object.
            FormsAuthenticationCredentials newformsAuthenticationCredentials = 
                new FormsAuthenticationCredentials();

            // </Snippet2>



            // <Snippet3>
            // Get the current PasswordFormat property value.
            FormsAuthPasswordFormat currentPasswordFormat =
            formsAuthenticationCredentials.PasswordFormat;


            // Set the PasswordFormat property value.
            formsAuthenticationCredentials.PasswordFormat = 
                FormsAuthPasswordFormat.SHA1;

            // </Snippet3>

            // <Snippet4>

            // Create a new FormsAuthenticationUserCollection object.
            FormsAuthenticationUserCollection newformsAuthenticationUser = 
                new FormsAuthenticationUserCollection();

            // </Snippet4>

            // <Snippet5>
            // Display all credentials collection elements.
            StringBuilder credentials = new StringBuilder();
            for (System.Int32 i = 0; 
                i < formsAuthenticationCredentials.Users.Count; 
                i++)
            {
                credentials.Append("User: " + 
                    formsAuthenticationCredentials.Users[i].Name);
                credentials.Append("Password: " + 
                    formsAuthenticationCredentials.Users[i].Password);
                credentials.Append(Environment.NewLine);
            }
            // </Snippet5>


            // <Snippet6>
            // Using method Add.

            // Define the SHA1 encrypted password.
            string password = 
                "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8";
            // Define the user name.
            string userName = "newUser";

            // Create the new user.
            FormsAuthenticationUser currentUser = 
                new FormsAuthenticationUser(userName, password);

            // Execute the Add method.
            formsAuthenticationCredentials.Users.Add(currentUser);

            // Update if not locked
            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }

            // </Snippet6>


            // <Snippet7>
            // Using method Clear.
            formsAuthenticationCredentials.Users.Clear();
            // Update if not locked
            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }
            // </Snippet7>


            // <Snippet9>
            // Using method Remove.
            // Execute the Remove method.
            formsAuthenticationCredentials.Users.Remove("userName");

            // Update if not locked
            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }
            // </Snippet9>

            // <Snippet10>
            // Using method RemoveAt.
            formsAuthenticationCredentials.Users.RemoveAt(0);

            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }
            // </Snippet10>


            // <Snippet11>
            // Using method Set.

            // Define the SHA1 encrypted password.
            string newPassword = 
                "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8";
            // Define the user name.
            string currentUserName = "userName";

            // Create the new user.
            FormsAuthenticationUser theUser = 
                new FormsAuthenticationUser(currentUserName, newPassword);

            formsAuthenticationCredentials.Users.Set(theUser);

            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }
            // </Snippet11>

            // <Snippet12>
            // Get the user with the specified name.
            FormsAuthenticationUser storedUser = 
                formsAuthenticationCredentials.Users.Get("userName");

            // </Snippet12>

            // <Snippet13>
            // Get the user at the specified index.
            FormsAuthenticationUser storedUser2 = 
                formsAuthenticationCredentials.Users.Get(0);

            // </Snippet13>

            // <Snippet14>
            // Get the key at the specified index.
            string thisKey = formsAuthenticationCredentials.Users.GetKey(0).ToString();

            // </Snippet14>

            // <Snippet15>
            // Get the user element at the specified index.
            FormsAuthenticationUser storedUser3 = 
                formsAuthenticationCredentials.Users[0];

            // </Snippet15>

            // <Snippet16>
            // Get the user element with the specified name.
            FormsAuthenticationUser storedUser4 = 
                formsAuthenticationCredentials.Users["userName"];

            // </Snippet16>

            // <Snippet17>
            // Get the collection keys.
            object [] keys = 
                formsAuthenticationCredentials.Users.AllKeys;
            // </Snippet17>

        }

    }

} 



