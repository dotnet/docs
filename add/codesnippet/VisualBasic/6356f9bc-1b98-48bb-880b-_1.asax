        routes.MapPageRoute("ExpenseCurrentYearRoute",
            "ExpenseReportCurrent/{locale}", "~/expenses.aspx",
            false,
            new RouteValueDictionary(New With _
                { .locale = "US", .year = DateTime.Now.Year.ToString()}),
            new RouteValueDictionary(New With _
                { .locale = "[a-z]{2}", .year = "\d{4}" }))