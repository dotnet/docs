        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' A parameter for the lambda expression.
        Dim paramExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "arg")

        ' This expression represents a lambda expression
        ' that adds 1 to the parameter value.
        Dim lambdaExpr As LambdaExpression = Expression.Lambda(
                Expression.Add(
                    paramExpr,
                    Expression.Constant(1)
                ),
                New List(Of ParameterExpression)() From {paramExpr}
            )

        ' Print out the expression.
        Console.WriteLine(lambdaExpr)

        ' Compile and run the lamda expression.
        ' The value of the parameter is 1.
        Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1))

        ' This code example produces the following output:
        '
        ' arg => (arg +1)
        ' 2