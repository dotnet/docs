        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression perfroms a logical OR operation
        ' on its two arguments, but if the first argument is true,
        ' the second arument is not evaluated.
        ' Both arguments must be of the Boolean type.
        Dim orElseExpr As Expression = Expression.OrElse(
             Expression.Constant(False),
             Expression.Constant(True)
         )

        ' Print the expression.
        Console.WriteLine(orElseExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(orElseExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (False OrElse True)
        ' True
