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