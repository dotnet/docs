        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression performs a logical AND operation
        ' on its two arguments, but if the first argument is false,
        ' the second argument is not evaluated.
        ' Both arguments must be of the Boolean type.
        Dim andAlsoExpr As Expression = Expression.AndAlso(
             Expression.Constant(False),
             Expression.Constant(True)
         )

        ' Print the expression.
        Console.WriteLine(andAlsoExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(andAlsoExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (False AndAlso True)
        ' False
