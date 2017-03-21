        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression represents the default value of a type
        ' (0 for integer, null for a string, and so on).
        Dim defaultExpr As Expression = Expression.Default(
                                                GetType(Byte)
                                            )

        ' Print the expression.
        Console.WriteLine(defaultExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Byte))(defaultExpr).Compile()())

        ' This code example produces the following output:
        '
        ' default(Byte)
        ' 0