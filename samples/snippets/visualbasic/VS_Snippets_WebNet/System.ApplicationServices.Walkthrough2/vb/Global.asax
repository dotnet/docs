<%@ Application Language="VB" %>

<script runat="server">
    '<snippet1> 
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        If Not Roles.RoleExists("Managers") Then
            Roles.CreateRole("Managers")
        End If
        If Not Roles.RoleExists("Friends") Then
            Roles.CreateRole("Friends")
        End If
    End Sub
    '</snippet1> 
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