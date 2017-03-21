        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' The parameter expression is used to create a variable.
        Dim variableExpr As ParameterExpression = Expression.Variable(GetType(Integer), "sampleVar")

        ' The block expression enables you to execute several expressions sequentually.
        ' In this block, the variable is first initialized with 1. 
        ' Then the AddAssign method adds 2 to the variable and assigns the result to the variable.
        Dim addAssignExpr As BlockExpression = Expression.Block(
            New ParameterExpression() {variableExpr},
            Expression.Assign(variableExpr, Expression.Constant(1)),
            Expression.AddAssign(
                variableExpr,
                Expression.Constant(2)
            )
        )

        ' Print the expression from the block expression.
        Console.WriteLine("The expressions from the block expression:")
        For Each expr As Expression In addAssignExpr.Expressions
            Console.WriteLine(expr.ToString())
        Next

        Console.WriteLine("The result of executing the expression tree:")
        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(addAssignExpr).Compile()())

        ' This code example produces the following output:
        '
        ' The expressions from the block expression:
        ' (sampleVar = 1)
        ' (sampleVar += 2)

        ' The result of executing the expression tree:
        ' 3