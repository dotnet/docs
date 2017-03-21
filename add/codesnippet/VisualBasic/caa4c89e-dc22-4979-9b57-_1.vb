        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression multiplies its two arguments.
        ' Both arguments must be of the same type.
        Dim multiplyExpr As Expression = Expression.Multiply(
            Expression.Constant(10),
            Expression.Constant(4)
        )

        ' Print the expression.
        Console.WriteLine(multiplyExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Integer))(multiplyExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (10*4)
        ' 40