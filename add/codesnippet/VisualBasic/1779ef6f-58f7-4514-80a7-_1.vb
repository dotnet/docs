        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression performs a logical AND operation
        ' on its two arguments. Both arguments must be of the same type,
        ' which can be Boolean or integer.             
        Dim andExpr As Expression = Expression.And(
            Expression.Constant(True),
            Expression.Constant(False)
            )

        ' Print the expression.
        Console.WriteLine(andExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.       
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(andExpr).Compile()())
        ' This code example produces the following output:
        '
        ' (True And False)
        ' False