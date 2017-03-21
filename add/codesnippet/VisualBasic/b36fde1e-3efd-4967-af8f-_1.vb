        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions 

        ' A TryExpression object that has a Catch statement.
        ' The return types of the Try block and all Catch blocks must be the same.
        Dim tryCatchExpr As TryExpression =
               Expression.TryCatch(
                   Expression.Block(
                       Expression.Throw(Expression.Constant(New DivideByZeroException())),
                       Expression.Constant("Try block")
                   ),
                   Expression.Catch(
                       GetType(DivideByZeroException),
                       Expression.Constant("Catch block")
                   )
               )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        ' If the exception is caught, 
        ' the result of the TryExpression is the last statement 
        ' of the corresponding Catch statement.
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(tryCatchExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Catch block