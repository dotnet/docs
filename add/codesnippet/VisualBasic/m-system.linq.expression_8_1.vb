        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a constant value.
        Dim constantExpr As Expression = Expression.Constant(5.5)

        ' Print the expression.
        Console.WriteLine(constantExpr.ToString())

        ' You can also use variables.
        Dim num As Double = 3.5
        constantExpr = Expression.Constant(num)
        Console.WriteLine(constantExpr.ToString())

        ' This code example produces the following output:
        '
        ' 5.5
        ' 3.5