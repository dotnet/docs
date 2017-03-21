            // Using method Remove.
            // Execute the Remove method.
            formsAuthenticationCredentials.Users.Remove("userName");

            // Update if not locked
            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }