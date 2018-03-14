<%@ Application Language="VB" %>

<script runat="server">
    '<snippet1>
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim originalPath As String = HttpContext.Current.Request.Path.ToLower()
        If originalPath.Contains("/page1") Then
            Context.RewritePath(originalPath.Replace("/page1", "/RewritePath.aspx?page=page1"))
        End If
        If originalPath.Contains("/page2") Then
            Context.RewritePath(originalPath.Replace("/page2", "/RewritePath.aspx"), "pathinfo", "page=page2")
        End If
    End Sub
    '</snippet1>
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
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