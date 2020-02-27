<%-- <Snippet1> --%>
<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">


    Private Sub Application_Start(ByVal sender As Object, 
        ByVal e As EventArgs)

        RegisterRoutes(RouteTable.Routes)
    End Sub

    Private Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.MapPageRoute("ProductRoute", 
            "ProductPage/{productname}/{*culture}", 
            "~/product.aspx")
    End Sub

</script>
<%-- </Snippet1> --%>

