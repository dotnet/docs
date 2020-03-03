Module Module1

    Sub Main()
        ' Test section
        Dim companies = 
            {"Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light", 
             "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works", 
             "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders", 
             "Blue Yonder Airlines", "Trey Research", "The Phone Company", 
             "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"}
        Dim results = companies.Where(Function(company) company.ToLower() = "coho winery" OrElse company.Length > 16).OrderBy(Function(company) company)
        For Each company As String In results
            Console.WriteLine(company)
        Next
        ' End test section

        Console.WriteLine()
        QueryableDynamicQuery()
        Console.WriteLine()
        EnumerableDynamicQuery()
    End Sub

    Sub QueryableDynamicQuery()
        ' <Snippet1>
        ' Add an Imports statement for System.Linq.Expressions.

        Dim companies = 
            {"Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light", 
             "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works", 
             "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders", 
             "Blue Yonder Airlines", "Trey Research", "The Phone Company", 
             "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"}

        ' The IQueryable data to query.
        Dim queryableData As IQueryable(Of String) = companies.AsQueryable()

        ' Compose the expression tree that represents the parameter to the predicate.
        Dim pe As ParameterExpression = Expression.Parameter(GetType(String), "company")

        ' ***** Where(Function(company) company.ToLower() = "coho winery" OrElse company.Length > 16) *****
        ' Create an expression tree that represents the expression: company.ToLower() = "coho winery".
        Dim left As Expression = Expression.Call(pe, GetType(String).GetMethod("ToLower", System.Type.EmptyTypes))
        Dim right As Expression = Expression.Constant("coho winery")
        Dim e1 As Expression = Expression.Equal(left, right)

        ' Create an expression tree that represents the expression: company.Length > 16.
        left = Expression.Property(pe, GetType(String).GetProperty("Length"))
        right = Expression.Constant(16, GetType(Integer))
        Dim e2 As Expression = Expression.GreaterThan(left, right)

        ' Combine the expressions to create an expression tree that represents the
        ' expression: company.ToLower() = "coho winery" OrElse company.Length > 16).
        Dim predicateBody As Expression = Expression.OrElse(e1, e2)

        ' Create an expression tree that represents the expression:
        ' queryableData.Where(Function(company) company.ToLower() = "coho winery" OrElse company.Length > 16)
        Dim whereCallExpression As MethodCallExpression = Expression.Call( 
                GetType(Queryable), 
                "Where", 
                New Type() {queryableData.ElementType}, 
                queryableData.Expression, 
                Expression.Lambda(Of Func(Of String, Boolean))(predicateBody, New ParameterExpression() {pe}))
        ' ***** End Where *****

        ' ***** OrderBy(Function(company) company) *****
        ' Create an expression tree that represents the expression:
        ' whereCallExpression.OrderBy(Function(company) company)
        Dim orderByCallExpression As MethodCallExpression = Expression.Call( 
                GetType(Queryable), 
                "OrderBy", 
                New Type() {queryableData.ElementType, queryableData.ElementType}, 
                whereCallExpression, 
                Expression.Lambda(Of Func(Of String, String))(pe, New ParameterExpression() {pe}))
        ' ***** End OrderBy *****

        ' Create an executable query from the expression tree.
        Dim results As IQueryable(Of String) = queryableData.Provider.CreateQuery(Of String)(orderByCallExpression)

        ' Enumerate the results.
        For Each company As String In results
            Console.WriteLine(company)
        Next

        ' This code produces the following output:
        '
        ' Blue Yonder Airlines
        ' City Power & Light
        ' Coho Winery
        ' Consolidated Messenger
        ' Graphic Design Institute
        ' Humongous Insurance
        ' Lucerne Publishing
        ' Northwind Traders
        ' The Phone Company
        ' Wide World Importers

        ' </Snippet1>
    End Sub

    ' <Snippet2>
    Sub EnumerableDynamicQuery()
        ' The IEnumerable data to query.
        Dim companies = 
            {"Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light", 
             "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works", 
             "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
             "Blue Yonder Airlines", "Trey Research", "The Phone Company", 
             "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"}

        ' Compose the expression tree that represents the parameter to the predicate.
        Dim pe As ParameterExpression = Expression.Parameter(GetType(String), "company")

        ' ***** Where(Function(company) company.ToLower() = "coho winery" OrElse company.Length > 16) *****
        ' Create an expression tree that represents the expression: company.ToLower() = "coho winery".
        Dim left As Expression = Expression.Call(pe, GetType(String).GetMethod("ToLower", System.Type.EmptyTypes))
        Dim right As Expression = Expression.Constant("coho winery")
        Dim e1 As Expression = Expression.Equal(left, right)

        ' Create an expression tree that represents the expression: company.Length > 16.
        left = Expression.Property(pe, GetType(String).GetProperty("Length"))
        right = Expression.Constant(16, GetType(Integer))
        Dim e2 As Expression = Expression.GreaterThan(left, right)

        ' Combine the expressions to create an expression tree that represents the
        ' expression: company.ToLower() = "coho winery" OrElse company.Length > 16.
        Dim predicateBody As Expression = Expression.OrElse(e1, e2)

        ' Create an expression tree that represents the expression:
        ' queryableData.Where(Function(company) company.ToLower() = "coho winery" OrElse company.Length > 16)
        Dim whereCallExpression As MethodCallExpression = Expression.Call( 
                GetType(Enumerable), 
                "Where", 
                New Type() {GetType(String)}, 
                Expression.Constant(companies), 
                Expression.Lambda(Of Func(Of String, Boolean))(predicateBody, New ParameterExpression() {pe}))
        ' ***** End Where *****

        ' ***** OrderBy(Function(company) company) *****
        ' Create an expression tree that represents the expression:
        ' whereCallExpression.OrderBy(Function(company) company)
        Dim orderByCallExpression As MethodCallExpression = Expression.Call( 
                GetType(Enumerable),
                "OrderBy", 
                New Type() {GetType(String), GetType(String)}, 
                whereCallExpression, 
                Expression.Lambda(Of Func(Of String, String))(pe, New ParameterExpression() {pe}))
        ' ***** End OrderBy *****

        ' Create an executable query from the expression tree.
        Dim deleg As Func(Of IEnumerable(Of String)) = 
            Expression.Lambda(Of Func(Of IEnumerable(Of String)))(orderByCallExpression).Compile()
        Dim results As IEnumerable(Of String) = deleg()

        ' Enumerate the results.
        For Each company As String In results
            Console.WriteLine(company)
        Next
    End Sub
    ' </Snippet2>
End Module