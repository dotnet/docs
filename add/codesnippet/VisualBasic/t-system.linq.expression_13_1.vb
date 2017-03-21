        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions  
        ' Creating a parameter expression.
        Dim value As ParameterExpression =
            Expression.Parameter(GetType(Integer), "value")

        ' Creating an expression to hold a local variable. 
        Dim result As ParameterExpression =
            Expression.Parameter(GetType(Integer), "result")

        ' Creating a label to jump to from a loop.
        Dim label As LabelTarget = Expression.Label(GetType(Integer))

        ' Creating a method body.
        Dim block As BlockExpression = Expression.Block(
            New ParameterExpression() {result},
            Expression.Assign(result, Expression.Constant(1)),
            Expression.Loop(
                Expression.IfThenElse(
                    Expression.GreaterThan(value, Expression.Constant(1)),
                    Expression.MultiplyAssign(result,
                        Expression.PostDecrementAssign(value)),
                    Expression.Break(label, result)
                ),
                label
            )
        )

        ' Compile an expression tree and return a delegate.
        Dim factorial As Integer =
            Expression.Lambda(Of Func(Of Integer, Integer))(block, value).Compile()(5)

        Console.WriteLine(factorial)

        ' This code example produces the following output:
        '
        ' 120