        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a NOT operation.
        Dim notExpr As Expression = Expression.Not(Expression.Constant(True))

        Console.WriteLine(notExpr)
        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(notExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Not(True)
        ' False