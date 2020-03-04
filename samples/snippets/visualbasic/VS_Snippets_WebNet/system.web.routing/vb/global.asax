<%-- <Snippet104> --%>
<%@ Application Language="VB" %>
<%-- <Snippet10> --%>
<%@ Import Namespace="System.Web.Routing" %>
<%-- </Snippet10> --%>

<script RunAt="server">

    '<Snippet30>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    '</Snippet30>
    '</Snippet104>
    
    '<Snippet105>
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        '</Snippet105>
        '<Snippet40>
        routes.MapPageRoute("", _
            "SalesReportSummary/{year}", _
            "~/sales.aspx")
        '</Snippet40>
        
        '<Snippet50>
        routes.MapPageRoute("SalesRoute", _
            "SalesReport/{locale}/{year}", _
            "~/sales.aspx")
        '</Snippet50>
        
        '<Snippet60>
        routes.MapPageRoute("ExpensesRoute", _
            "ExpenseReport/{locale}/{year}/{*extrainfo}", _
            "~/expenses.aspx", True, _
            New RouteValueDictionary(New With _
                {.locale = "US", .year = DateTime.Now.Year.ToString()}), _
            New RouteValueDictionary(New With _
                {.locale = "[a-z]{2}", .year = "\d{4}"}))
        '</Snippet60>

        '<Snippet106>
        routes.MapPageRoute("ProductRoute",
            "ProductPage/{productname}/{*culture}",
             "~/product.aspx")
    End Sub
</script>
<%-- </Snippet106> --%>
