            // Using method RemoveAt.
            formsAuthenticationCredentials.Users.RemoveAt(0);

            if (!authenticationSection.SectionInformation.IsLocked)
            {
                configuration.Save();
            }