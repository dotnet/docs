        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' To demonstrate the assignment operation, create a variable.
        Dim variableExpr As ParameterExpression = Expression.Variable(GetType(String), "sampleVar")

        ' This expression represents the assignment of a value
        ' to a variable expression.
        ' It copies a value for value types, and it
        ' copies a reference for reference types.
        Dim assignExpr As Expression = Expression.Assign(
            variableExpr,
            Expression.Constant("Hello World!")
            )

        ' The block expression allows for executing several expressions sequentually.
        ' In this block, you pass the variable expression as a parameter,
        ' and then assign this parameter a value in the assign expression.
        Dim blockExpr As Expression = Expression.Block(
              New ParameterExpression() {variableExpr}, assignExpr
              )

        ' Print the assign expression.
        Console.WriteLine(assignExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(blockExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (sampleVar = "Hello World!")
        ' Hello World!