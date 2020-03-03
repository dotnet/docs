<%@ Application Language="C#" %>

<script runat="server">

    //<Snippet1>
    void Application_Start(object sender, EventArgs e) 
    {
        System.Web.ApplicationServices.ProfileService.ValidatingProperties += new EventHandler<System.Web.ApplicationServices.ValidatingPropertiesEventArgs>(ProfileService_ValidatingProperties);
    }

    void ProfileService_ValidatingProperties(object sender, System.Web.ApplicationServices.ValidatingPropertiesEventArgs e)
    {
        if (String.IsNullOrEmpty((string)e.Properties["FirstName"]))
        {
            e.FailedProperties.Add("FirstName");
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

