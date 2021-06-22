Imports System.Reflection
Imports System.Linq.Expressions.Expression
Imports ExpressionTreeToString

Module Program
    ' <Initialize>
    Dim companyNames As String() = {
        "Consolidated Messenger", "Alpine Ski House", "Southridge Video",
        "City Power & Light", "Coho Winery", "Wide World Importers",
        "Graphic Design Institute", "Adventure Works", "Humongous Insurance",
        "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
        "Blue Yonder Airlines", "Trey Research", "The Phone Company",
        "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
    }

    ' We're using an in-memory array as the data source, but the IQueryable could have come
    ' from anywhere -- an ORM backed by a database, a web request, Or any other LINQ provider.
    Dim companyNamesSource As IQueryable(Of String) = companyNames.AsQueryable
    Dim fixedQry = companyNamesSource.OrderBy(Function(x) x)
    ' </Initialize>

    Sub RuntimeStateFromWithinExpressionTree()
        ' <Runtime_state_from_within_expression_tree>
        Dim length = 1
        Dim qry = companyNamesSource.
            Select(Function(x) x.Substring(0, length)).
            Distinct

        Console.WriteLine(String.Join(", ", qry))
        ' prints: C, A, S, W, G, H, M, N, B, T, L, F

        length = 2
        Console.WriteLine(String.Join(", ", qry))
        ' prints: Co, Al, So, Ci, Wi, Gr, Ad, Hu, Wo, Ma, No, Bl, Tr, Th, Lu, Fo
        ' </Runtime_state_from_within_expression_tree>
    End Sub

    Sub AddedMethodCalls()
        Dim sortByLength = True

        ' <Added_method_calls>
        ' Dim sortByLength As Boolean  = ...

        Dim qry = companyNamesSource
        If sortByLength Then qry = qry.OrderBy(Function(x) x.Length)
        ' </Added_method_calls>
    End Sub

    Sub VaryingExpressions()
        Dim startsWith = ""
        Dim endsWith = ""

        ' <Varying_expressions>
        ' Dim startsWith As String = ...
        ' Dim endsWith As String = ...

        Dim expr As Expression(Of Func(Of String, Boolean))
        If String.IsNullOrEmpty(startsWith) AndAlso String.IsNullOrEmpty(endsWith) Then
            expr = Function(x) True
        ElseIf String.IsNullOrEmpty(startsWith) Then
            expr = Function(x) x.EndsWith(endsWith)
        ElseIf String.IsNullOrEmpty(endsWith) Then
            expr = Function(x) x.StartsWith(startsWith)
        Else
            expr = Function(x) x.StartsWith(startsWith) AndAlso x.EndsWith(endsWith)
        End If
        Dim qry = companyNamesSource.Where(expr)
        ' </Varying_expressions>
    End Sub

    Sub ComposeExpression()
        Dim startsWith = ""
        Dim endsWith = ""

        ' <Compose_expression>
        ' This is functionally equivalent to the previous example.

        ' Imports LinqKit
        ' Dim startsWith As String = ...
        ' Dim endsWith As String = ...

        Dim expr As Expression(Of Func(Of String, Boolean)) = PredicateBuilder.[New](Of String)(False)
        Dim original = expr
        If Not String.IsNullOrEmpty(startsWith) Then expr = expr.Or(Function(x) x.StartsWith(startsWith))
        If Not String.IsNullOrEmpty(endsWith) Then expr = expr.Or(Function(x) x.EndsWith(endsWith))
        If expr Is original Then expr = Function(x) True

        Dim qry = companyNamesSource.Where(expr)
        ' </Compose_expression>
    End Sub

    Sub CompilerGeneratedExpression()
        ' <Compiler_generated>
        Dim expr As Expression(Of Func(Of String, Boolean)) = Function(x As String) x.StartsWith("a")
        ' </Compiler_generated>
    End Sub

    Sub FactoryMethodExpression()
        ' <Factory_method_parameter>
        Dim x As ParameterExpression = Parameter(GetType(String), "x")
        ' </Factory_method_parameter>

        ' <Factory_method_body>
        Dim body As Expression = [Call](
            x,
            GetType(String).GetMethod("StartsWith", {GetType(String)}),
            Constant("a")
        )
        ' </Factory_method_body>

        ' <Factory_method_lambda>
        Dim expr As Expression(Of Func(Of String, Boolean)) =
            Lambda(Of Func(Of String, Boolean))(body, x)
        ' </Factory_method_lambda>
    End Sub

    ' <Factory_methods_expression_of_tdelegate>
    ' Imports System.Linq.Expressions.Expression
    Function TextFilter(Of T)(source As IQueryable(Of T), term As String) As IQueryable(Of T)
        If String.IsNullOrEmpty(term) Then Return source

        ' T is a compile-time placeholder for the element type of the query
        Dim elementType = GetType(T)

        ' Get all the string properties on this specific type
        Dim stringProperties As PropertyInfo() =
            elementType.GetProperties.
                Where(Function(x) x.PropertyType = GetType(String)).
                ToArray
        If stringProperties.Length = 0 Then Return source

        ' Get the right overload of String.Contains
        Dim containsMethod As MethodInfo =
            GetType(String).GetMethod("Contains", {GetType(String)})

        ' Create the parameter for the expression tree --
        ' the 'x' in 'Function(x) x.PropertyName.Contains("term")'
        ' The type of the parameter is the query's element type
        Dim prm As ParameterExpression =
            Parameter(elementType)

        ' Generate an expression tree node corresponding to each property
        Dim expressions As IEnumerable(Of Expression) =
            stringProperties.Select(Of Expression)(Function(prp)
                                                       ' For each property, we want an expression node like this:
                                                       ' x.PropertyName.Contains("term")
                                                       Return [Call](      ' .Contains(...)
                                                           [Property](     ' .PropertyName
                                                               prm,        ' x
                                                               prp
                                                           ),
                                                           containsMethod,
                                                           Constant(term)  ' "term"
                                                       )
                                                   End Function)

        ' Combine the individual nodes into a single expression tree node using OrElse
        Dim body As Expression =
            expressions.Aggregate(Function(prev, current) [OrElse](prev, current))

        ' Wrap the expression body in a compile-time-typed lambda expression
        Dim lmbd As Expression(Of Func(Of T, Boolean)) =
            Lambda(Of Func(Of T, Boolean))(body, prm)

        ' Because the lambda is compile-time-typed, we can use it with the Where method
        Return source.Where(lmbd)
    End Function
    ' </Factory_methods_expression_of_tdelegate>

    Sub TextFilterUsage()
        ' <Factory_methods_expression_of_tdelegate_usage>
        Dim qry = TextFilter(
            (New List(Of Person)).AsQueryable,
            "abcd"
        ).Where(Function(x) x.DateOfBirth < #1/1/2001#)

        Dim qry1 = TextFilter(
            (New List(Of Car)).AsQueryable,
            "abcd"
        ).Where(Function(x) x.Year = 2010)
        ' </Factory_methods_expression_of_tdelegate_usage>
    End Sub

    Function ConstructBody(elementType As Type, term As String) As (Expression, ParameterExpression)
        If String.IsNullOrEmpty(term) Then Return Nothing
        Dim stringProperties = elementType.GetProperties.
                Where(Function(x) x.PropertyType = GetType(String)).
                ToArray
        If stringProperties.Length = 0 Then Return Nothing
        Dim containsMethod = GetType(String).GetMethod("Contains", {GetType(String)})
        Dim prm = Parameter(elementType)
        Dim body = stringProperties.Select(Of Expression)(Function(prp)
                                                              Return [Call](
                                                   [Property](prm, prp),
                                                   containsMethod,
                                                   Constant(term)
                                               )
                                                          End Function).
                                           Aggregate(Function(prev, current) [OrElse](prev, current))
        Return (body, prm)
    End Function

    Sub ManualTextFilter()
        Dim term = "abcd"

        ' <PersonsQry>
        ' Dim term = ...
        Dim personsQry = (New List(Of Person)).AsQueryable.
            Where(Function(x) x.FirstName.Contains(term) OrElse x.LastName.Contains(term))
        ' </PersonsQry>

        ' <CarsQry>
        ' Dim term = ...
        Dim carsQry = (New List(Of Car)).AsQueryable.
            Where(Function(x) x.Model.Contains(term))
        ' </CarsQry>
    End Sub

    ' <Factory_methods_lambdaexpression>
    Function TextFilter_Untyped(source As IQueryable, term As String) As IQueryable
        If String.IsNullOrEmpty(term) Then Return source
        Dim elementType = source.ElementType

        ' The logic for building the ParameterExpression And the LambdaExpression's body is the same as in
        ' the previous example, but has been refactored into the ConstructBody function.
        Dim x As (Expression, ParameterExpression) = ConstructBody(elementType, term)
        Dim body As Expression = x.Item1
        Dim prm As ParameterExpression = x.Item2
        If body Is Nothing Then Return source

        Dim filteredTree As Expression = [Call](
            GetType(Queryable),
            "Where",
            {elementType},
            source.Expression,
            Lambda(body, prm)
        )

        Return source.Provider.CreateQuery(filteredTree)
    End Function
    ' </Factory_methods_lambdaexpression>

    Sub TextFilter_Untyped_Usage()
        Dim qry = TextFilter_Untyped(
            (New List(Of Person)).AsQueryable(),
            "abcd"
        )
    End Sub

    ' <Dynamic_linq>
    ' Imports System.Linq.Dynamic.Core

    Function TextFilter_Strings(source As IQueryable, term As String) As IQueryable
        If String.IsNullOrEmpty(term) Then Return source

        Dim elementType = source.ElementType
        Dim stringProperties = elementType.GetProperties.
                Where(Function(x) x.PropertyType = GetType(String)).
                ToArray
        If stringProperties.Length = 0 Then Return source

        Dim filterExpr = String.Join(
            " || ",
            stringProperties.Select(Function(prp) $"{prp.Name}.Contains(@0)")
        )

        Return source.Where(filterExpr, term)
    End Function
    ' </Dynamic_linq>

    Sub TextFilter_Strings_Usage()
        Dim qry = (New List(Of Person)).AsQueryable
        qry = TextFilter_Strings(qry, "abcd")
    End Sub

    Sub Main()
        RuntimeStateFromWithinExpressionTree()
        AddedMethodCalls()
        VaryingExpressions()
        ComposeExpression()
        TextFilterUsage()
        TextFilter_Untyped_Usage()
        TextFilter_Strings_Usage()
    End Sub
End Module
