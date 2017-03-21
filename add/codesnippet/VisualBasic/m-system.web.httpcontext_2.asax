    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim originalPath As String = HttpContext.Current.Request.Path.ToLower()
        If originalPath.Contains("/page1") Then
            Context.RewritePath(originalPath.Replace("/page1", "/RewritePath.aspx?page=page1"))
        End If
        If originalPath.Contains("/page2") Then
            Context.RewritePath(originalPath.Replace("/page2", "/RewritePath.aspx"), "pathinfo", "page=page2")
        End If
    End Sub