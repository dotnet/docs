        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression perfroms a logical OR operation
        ' on its two arguments. Both arguments must be of the same type,
        ' which can be Boolean or integer.             
        Dim orExpr As Expression = Expression.Or(
             Expression.Constant(True),
             Expression.Constant(False)
         )

        ' Print the expression.
        Console.WriteLine(orExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.       
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(orExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (True Or False)
        ' True