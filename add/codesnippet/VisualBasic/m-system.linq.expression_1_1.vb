        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions

        ' The block expression enables you to execute several expressions sequentually.
        ' When the block expression is executed,
        ' it returns the value of the last expression in the sequence.
        Dim blockExpr As BlockExpression = Expression.Block(
            Expression.Call(
                Nothing,
                GetType(Console).GetMethod("Write", New Type() {GetType(String)}),
                Expression.Constant("Hello ")
               ),
            Expression.Call(
                Nothing,
                GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                Expression.Constant("World!")
                ),
            Expression.Constant(42)
        )

        Console.WriteLine("The result of executing the expression tree:")
        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.           
        Dim result = Expression.Lambda(Of Func(Of Integer))(blockExpr).Compile()()

        ' Print the expressions from the block expression.
        Console.WriteLine("The expressions from the block expression:")
        For Each expr In blockExpr.Expressions
            Console.WriteLine(expr.ToString())
        Next

        ' Print the result of the tree execution.
        Console.WriteLine("The return value of the block expression:")
        Console.WriteLine(result)

        ' This code example produces the following output:
        '
        ' The result of executing the expression tree:
        ' Hello World!

        ' The expressions from the block expression:
        ' Write("Hello ")
        ' WriteLine("World!")
        ' 42

        ' The return value of the block expression:
        ' 42