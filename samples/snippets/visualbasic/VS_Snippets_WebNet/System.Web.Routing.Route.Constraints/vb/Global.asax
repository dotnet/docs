<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    ' <Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim urlPattern As String
        Dim reportRoute As Route
        Dim allowedMethods() As String = {"GET", "POST"}
        Dim methodConstraints As HttpMethodConstraint  
        
        methodConstraints = New HttpMethodConstraint(allowedMethods)
        
        Dim constraintValues = New With {.httpMethod = methodConstraints}
        
        urlPattern = "{locale}/{year}"
        
        reportRoute = New Route(urlPattern, New ReportRouteHandler)
        reportRoute.Constraints = New RouteValueDictionary(constraintValues)
        
        routes.Add(reportRoute)
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