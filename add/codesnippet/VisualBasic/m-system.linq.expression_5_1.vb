        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a negation operation.
        Dim negateExpr As Expression = Expression.Negate(Expression.Constant(5))

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(negateExpr).Compile()())

        ' This code example produces the following output:
        '
        ' -5