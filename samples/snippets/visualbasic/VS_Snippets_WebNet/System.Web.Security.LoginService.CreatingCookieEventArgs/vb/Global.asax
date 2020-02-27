<%@ Application Language="VB" %>

<script runat="server">

    '<Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.AuthenticationService.CreatingCookie, _
            AddressOf Me.AuthenticationService_CreatingCookie
    End Sub
    '</Snippet1>
    
    '<snippet2>
    Sub AuthenticationService_CreatingCookie(ByVal sender As Object, _
                     ByVal e As System.Web.ApplicationServices.CreatingCookieEventArgs)
        Dim ticket As FormsAuthenticationTicket = New _
           FormsAuthenticationTicket _
            (1, _
             e.Username, _
             DateTime.Now, _
             DateTime.Now.AddMinutes(30), _
             e.IsPersistent, _
             e.CustomCredential, _
             FormsAuthentication.FormsCookiePath)
            
        Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)
        
        Dim cookie As HttpCookie = New _
            HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
        cookie.Expires = DateTime.Now.AddMinutes(30)
        
        HttpContext.Current.Response.Cookies.Add(cookie)
        e.CookieIsSet = True
    End Sub
    '</snippet2>
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>