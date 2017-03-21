        routes.MapPageRoute("ExpenseDetailRoute",
            "ExpenseReportDetail/{locale}/{year}/{*queryvalues}", "~/expenses.aspx",
            false,
            new RouteValueDictionary(New With _
                { .locale = "US", .year = DateTime.Now.Year.ToString()}),
            new RouteValueDictionary(New With _ 
                { .locale = "[a-z]{2}", .year = "\d{4}" }),
            new RouteValueDictionary(New With _
                { .account = "1234", .subaccount = "5678" }))