        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        Dim num As Integer = 100

        ' This expression represents a conditional operation; 
        ' it will evaluate the test (first expression) and
        ' execute the ifTrue block (second argument) if the test evaluates to true, 
        ' or the ifFalse block (third argument) if the test evaluates to false.
        Dim conditionExpr As Expression = Expression.Condition(
                                    Expression.Constant(num > 10),
                                    Expression.Constant("n is greater than 10"),
                                    Expression.Constant("n is smaller than 10")
                                )

        ' Print the expression.
        Console.WriteLine(conditionExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.       
        Console.WriteLine(
            Expression.Lambda(Of Func(Of String))(conditionExpr).Compile()())

        ' This code example produces the following output:
        '
        ' IIF("True", "num is greater than 10", "num is smaller than 10")
        ' num is greater than 10