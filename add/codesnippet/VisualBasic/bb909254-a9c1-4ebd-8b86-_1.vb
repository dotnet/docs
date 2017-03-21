        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression represents an exclusive OR operation for its two arguments.
        ' Both arguments must be of the same type, 
        ' which can be either integer or Boolean.

        Dim exclusiveOrExpr As Expression = Expression.ExclusiveOr(
             Expression.Constant(5),
             Expression.Constant(3)
         )

        ' Print the expression.
        Console.WriteLine(exclusiveOrExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.           
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Integer))(exclusiveOrExpr).Compile()())

        ' The XOR operation is performed as follows:
        ' 101 xor 011 = 110

        ' This code example produces the following output:
        '
        ' (5 ^ 3)
        ' 6