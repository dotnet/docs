        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression subtracts the second argument 
        ' from the first argument.
        ' Both arguments must be of the same type.
        Dim subtractExpr As Expression = Expression.Subtract(
             Expression.Constant(12),
             Expression.Constant(3)
         )

        ' Print the expression.
        Console.WriteLine(subtractExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.            
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(subtractExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (12 - 3)
        ' 9