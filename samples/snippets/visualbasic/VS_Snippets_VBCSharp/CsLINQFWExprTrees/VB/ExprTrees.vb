Module Expr
    Sub Main(ByVal args As String())
        Example1()

        Example2()
        Example3()
        Example4()
        Example5()
        Console.ReadKey()

    End Sub

    Sub Example1()
        ' <Snippet1>

        ' Import the following namespace to your project: System.Linq.Expressions

        ' Create an expression tree.
        Dim exprTree As Expression(Of Func(Of Integer, Boolean)) = Function(num) num < 5

        ' Decompose the expression tree.
        Dim param As ParameterExpression = exprTree.Parameters(0)
        Dim operation As BinaryExpression = exprTree.Body
        Dim left As ParameterExpression = operation.Left
        Dim right As ConstantExpression = operation.Right

        Console.WriteLine(String.Format("Decomposed expression: {0} => {1} {2} {3}",
                          param.Name, left.Name, operation.NodeType, right.Value))

        ' This code produces the following output:
        '
        ' Decomposed expression: num => num LessThan 5

        ' </Snippet1>

    End Sub

    Sub Example2()
        ' <Snippet2>

        ' Import the following namespace to your project: System.Linq.Expressions

        ' Manually build the expression tree for the lambda expression num => num < 5.
        Dim numParam As ParameterExpression = Expression.Parameter(GetType(Integer), "num")
        Dim five As ConstantExpression = Expression.Constant(5, GetType(Integer))
        Dim numLessThanFive As BinaryExpression = Expression.LessThan(numParam, five)
        Dim lambda1 As Expression(Of Func(Of Integer, Boolean)) =
          Expression.Lambda(Of Func(Of Integer, Boolean))(
                numLessThanFive,
                New ParameterExpression() {numParam})
        ' </Snippet2>

    End Sub

    Sub Example3()
        ' <Snippet3>
        Dim lambda As Expression(Of Func(Of Integer, Boolean)) =
            Function(num) num < 5
        ' </Snippet3>
    End Sub

    Sub Example4()
        ' <Snippet4>
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
        ' Prints 120.
        ' </Snippet4>
    End Sub

    Sub Example5()
        ' <Snippet5>
        ' Creating an expression tree.
        Dim expr As Expression(Of Func(Of Integer, Boolean)) =
            Function(num) num < 5

        ' Compiling the expression tree into a delegate.
        Dim result As Func(Of Integer, Boolean) = expr.Compile()

        ' Invoking the delegate and writing the result to the console.
        Console.WriteLine(result(4))

        ' Prints True.

        ' You can also use simplified syntax
        ' to compile and run an expression tree.
        ' The following line can replace two previous statements.
        Console.WriteLine(expr.Compile()(4))

        ' Also prints True.
        ' </Snippet5>
    End Sub
End Module
