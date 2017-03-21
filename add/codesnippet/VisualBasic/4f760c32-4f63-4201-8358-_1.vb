        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a type convertion operation.        
        Dim convertExpr As Expression = Expression.Convert(
                                    Expression.Constant(5.5),
                                    GetType(Int16)
                                )

        ' Print the expression.
        Console.WriteLine(convertExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Int16))(convertExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Convert(5.5)
        ' 5
