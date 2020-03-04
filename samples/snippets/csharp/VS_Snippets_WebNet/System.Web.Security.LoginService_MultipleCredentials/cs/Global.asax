<%@ Application Language="C#" %>

<script runat="server">

    // <Snippet1>
    void Application_Start(object sender, EventArgs e) 
    {
        System.Web.ApplicationServices.AuthenticationService.Authenticating += 
            new EventHandler<System.Web.ApplicationServices.AuthenticatingEventArgs>(AuthenticationService_Authenticating);

    }
    // </Snippet1>

    // <Snippet2>
    void AuthenticationService_Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        string studentid = String.Empty;
        string answer = String.Empty;

        string[] credentials =
            e.CustomCredential.Split(new char[] { ',' });
        if (credentials.Length > 0)
        {
            studentid = credentials[0];
            if (credentials.Length > 1)
            {
                answer = credentials[1];
            }
        }

        try
        {
            e.Authenticated =
                StudentAuthentication.ValidateStudentCredentials
                (e.UserName, e.Password, studentid, answer);
        }
        catch (ArgumentNullException ex)
        {
            e.Authenticated = false;
        }

        e.AuthenticationIsComplete = true;
    }
    // </Snippet2>
    
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

    class StudentAuthentication
    {
        public static bool ValidateStudentCredentials(string username, string password, string studentid, string birthdate)
        {
            return true;
        }
    }
       
</script>
