        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression represents a call to an instance method without arguments.
        Dim callExpr As Expression = Expression.Call(
            Expression.Constant("sample string"), GetType(String).GetMethod("ToUpper", New Type() {}))

        ' Print the expression.
        Console.WriteLine(callExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.  
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(callExpr).Compile()())

        ' This code example produces the following output:
        '
        ' "sample string".ToUpper
        ' SAMPLE STRING
