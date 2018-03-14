<%@ Application Language="C#" %>

<script runat="server">
    //<Snippet1>
    void Application_Start(object sender, EventArgs e) 
    {
        System.Web.ApplicationServices.RoleService.SelectingProvider += 
            new EventHandler<System.Web.ApplicationServices.SelectingProviderEventArgs>(RoleService_SelectingProvider);
    }

    void RoleService_SelectingProvider
        (object sender, System.Web.ApplicationServices.SelectingProviderEventArgs e)
    {
        if (e.User.Identity.Name.IndexOf("@example.com") > 0)
        {
            e.ProviderName = "EmployeeRoleProvider";
        }
        else
        {
            e.ProviderName = "CustomerRoleProvider";
        }
    }
    //</Snippet1>
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
