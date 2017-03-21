    void AuthenticationService_Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        if (e.UserName.IndexOf("@contoso.com") >= 0)
        {
            e.Authenticated = Membership.Providers["ContosoSqlProvider"].ValidateUser(e.UserName, e.Password);
        }
        else if (e.UserName.IndexOf("@fabrikam.com") >= 0)
        {
            e.Authenticated = Membership.Providers["FabrikamSqlProvider"].ValidateUser(e.UserName, e.Password);
        }
        else
        {
            e.Authenticated = Membership.Provider.ValidateUser(e.UserName, e.Password);
        }
        e.AuthenticationIsComplete = true;
    }