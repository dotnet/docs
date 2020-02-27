<%-- <Snippet1> --%>
<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">


    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }

    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("ProductRoute",
            "ProductPage/{productname}/{*culture}",
             "~/product.aspx");
    }

</script>
<%-- </Snippet1> --%>

