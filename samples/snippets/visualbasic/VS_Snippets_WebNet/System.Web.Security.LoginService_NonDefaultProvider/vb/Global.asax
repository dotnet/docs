<%@ Application Language="VB" %>

<script runat="server">

    ' <Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.AuthenticationService.Authenticating, _
          AddressOf Me.AuthenticationService_Authenticating
    End Sub
    ' </Snippet1>
    
    ' <Snippet2>
    Sub AuthenticationService_Authenticating _
       (ByVal sender As Object, _
        ByVal e As System.Web.ApplicationServices.AuthenticatingEventArgs)
        
        If (e.Username.IndexOf("@contoso.com") >= 0) Then
            e.Authenticated = Membership.Providers("ContosoSqlProvider").ValidateUser(e.Username, e.Password)
        ElseIf (e.Username.IndexOf("@fabrikam.com") >= 0) Then
            e.Authenticated = Membership.Providers("FabrikamSqlProvider").ValidateUser(e.Username, e.Password)
        Else
            e.Authenticated = Membership.Provider.ValidateUser(e.Username, e.Password)
        End If
        e.AuthenticationIsComplete = True
    End Sub
    ' </Snippet2>
    
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