            // Using method Clear.
            formsAuthenticationCredentials.Users.Clear();
            // Update if not locked
            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }