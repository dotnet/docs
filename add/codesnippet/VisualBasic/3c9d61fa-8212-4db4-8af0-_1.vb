        'Add the following directive to your file:
        ' Imports System.Linq.Expressions   
        Dim num As Double = 5.5
        ' This expression represents an increment operation. 
        Dim incrementExpr As Expression = Expression.Increment(
                                    Expression.Constant(num)
                                )

        ' Print the expression.
        Console.WriteLine(incrementExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Double))(incrementExpr).Compile()())

        ' The value of the variable did not change,
        ' because the expression is functional.
        Console.WriteLine("object: " & num)

        ' This code example produces the following output:
        '
        ' Increment(5.5)
        ' 6.5
        ' object: 5.5