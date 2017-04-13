<%-- <Snippet104> --%>
<%@ Application Language="C#" %>
<%-- <Snippet10> --%>
<%@ Import Namespace="System.Web.Routing" %>
<%-- </Snippet10> --%>

<script RunAt="server">


    // <Snippet30>
    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }
    // </Snippet30>
    // </Snippet104>

    // <Snippet105>
    void RegisterRoutes(RouteCollection routes)
    {
        // </Snippet105>
        // <Snippet40>
        routes.MapPageRoute("",
            "SalesReportSummary/{year}",
            "~/sales.aspx");
        //</Snippet40>

        //<Snippet50>
        routes.MapPageRoute("SalesRoute",
            "SalesReport/{locale}/{year}",
            "~/sales.aspx");
        //</Snippet50>

        //<Snippet60>
        routes.MapPageRoute("ExpensesRoute",
            "ExpenseReport/{locale}/{year}/{*extrainfo}",
            "~/expenses.aspx", true,
            new RouteValueDictionary { 
                { "locale", "US" }, 
                { "year", DateTime.Now.Year.ToString() } },
            new RouteValueDictionary { 
                { "locale", "[a-z]{2}" }, 
                { "year", @"\d{4}" } });
        //</Snippet60>

        // <Snippet106>
        routes.MapPageRoute("ProductRoute",
            "ProductPage/{productname}/{*culture}",
             "~/product.aspx");
    }
</script>
<%-- </Snippet106> --%>

