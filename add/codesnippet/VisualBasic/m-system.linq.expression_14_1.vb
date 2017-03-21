        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression represents a constant value, 
        ' for which you can explicitly specify the type. 
        ' This can be used, for example, for defining constants of a nullable type.
        Dim constantExpr As Expression = Expression.Constant(
                                    Nothing,
                                    GetType(Double?)
                                )

        ' Print the expression.
        Console.WriteLine(constantExpr.ToString())

        ' This code example produces the following output:
        '
        ' null