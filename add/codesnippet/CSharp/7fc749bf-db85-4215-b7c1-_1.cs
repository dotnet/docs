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