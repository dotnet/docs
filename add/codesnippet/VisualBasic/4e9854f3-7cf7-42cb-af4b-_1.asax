        routes.MapPageRoute("",
            "SalesReport/{locale}/{year}/{*queryvalues}", "~/sales.aspx")

        routes.MapPageRoute("SalesSummaryRoute",
            "SalesReportSummary/{locale}", "~/sales.aspx")