            PassportIdentity identity = (this.Context.User.Identity as PassportIdentity);    
            // Determine whether the user is already signed in with a valid
            // and current ticket. Passing -1 for the parameter values 
            // indicates the default values will be used.
            if (identity.GetIsAuthenticated(-1, -1, -1))
            {
                this.Response.Write("Welcome to the site.<br /><br />");
                // Print the Passport sign in button on the screen.
                this.Response.Write(identity.LogoTag2());
                // Make sure the user has core profile information before
                // trying to access it.
                if (identity.HasProfile("core"))
                {
                    this.Response.Write("<b>You have been authenticated as " + 
                        "Passport identity:" + identity.Name + "</b></p>");
                }
            }
    
            // Determine whether the user has a ticket.
            else if (identity.HasTicket)
            {
                // If the user has a ticket but wasn't authenticated, that 
                // means the ticket is stale, so the login needs to be refreshed.
                // Passing true as the fForceLogin parameter value indicates that 
                // silent refresh will be accepted.
                identity.LoginUser(null, -1, true, null, -1, null, -1, true, null);
            }