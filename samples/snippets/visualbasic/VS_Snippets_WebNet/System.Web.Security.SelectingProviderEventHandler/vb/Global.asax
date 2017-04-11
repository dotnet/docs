<%@ Application Language="VB" %>

<script runat="server">

    '<Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.RoleService.SelectingProvider, _
            AddressOf Me.RoleService_SelectingProvider
    End Sub
    
    Sub RoleService_SelectingProvider _
    (ByVal sender As Object, _
     ByVal e As System.Web.ApplicationServices.SelectingProviderEventArgs)

        If (e.User.Identity.Name.IndexOf("@example.com") > 0) Then
            e.ProviderName = "EmployeeRoleProvider"
        Else
            e.ProviderName = "CustomerRoleProvider"
        End If
    End Sub
    '</Snippet1>

    
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