        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim lessThanExpr As Expression = Expression.LessThan(
            Expression.Constant(42),
            Expression.Constant(45)
        )

        ' Print the expression.
        Console.WriteLine(lessThanExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.    
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(lessThanExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (42 < 45)
        ' True