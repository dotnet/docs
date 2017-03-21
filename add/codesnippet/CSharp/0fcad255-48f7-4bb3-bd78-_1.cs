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
