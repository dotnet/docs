        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  


        ' This block has a parameter expression
        ' that represents a variable within the block scope.
        ' It assigns a value to the variable,
        ' and then adds a constant to the assigned value. 

        Dim varExpr As ParameterExpression = Expression.Variable(GetType(Integer), "sampleVar")
        Dim blockExpr As BlockExpression = Expression.Block(
            New ParameterExpression() {varExpr},
            Expression.Assign(varExpr, Expression.Constant(1)),
            Expression.Add(varExpr, Expression.Constant(5))
        )

        ' Print the expressions from the block expression.

        Console.WriteLine("The expressions from the block expression:")
        For Each expr In blockExpr.Expressions
            Console.WriteLine(expr.ToString())
        Next

        Console.WriteLine("The result of executing the expression tree:")

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Integer))(blockExpr).Compile()())

        ' This code example produces the following output:
        '
        ' The expressions from the block expression:
        ' (sampleVar = 1)
        ' (sampleVar + 5)
        ' The result of executing the expression tree:
        ' 6