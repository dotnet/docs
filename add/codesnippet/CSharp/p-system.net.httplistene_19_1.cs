    public static string ClientInformation(HttpListenerContext context)
    {
        System.Security.Principal.IPrincipal user = context.User;
        System.Security.Principal.IIdentity id = user.Identity;
        if (id == null)
        {
            return "Client authentication is not enabled for this Web server.";
        }
        
        string display;
        if (id.IsAuthenticated)
        {
            display = String.Format("{0} was authenticated using {1}", id.Name, 
                id.AuthenticationType);
        }
        else
        {
           display = String.Format("{0} was not authenticated", id.Name);
        }
        return display;
    }