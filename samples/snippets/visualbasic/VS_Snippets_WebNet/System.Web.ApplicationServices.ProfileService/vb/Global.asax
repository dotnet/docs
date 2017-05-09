<%@ Application Language="VB" %>

<script runat="server">

    ' <Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.ProfileService.ValidatingProperties, _
          AddressOf ProfileService_ValidatingProperties
    End Sub
    
    Sub ProfileService_ValidatingProperties(ByVal sender As Object, ByVal e As System.Web.ApplicationServices.ValidatingPropertiesEventArgs)
        If (String.IsNullOrEmpty(CType(e.Properties("FirstName"), String))) Then
            e.FailedProperties.Add("FirstName")
        End If
    End Sub
    ' </Snippet1>
    
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