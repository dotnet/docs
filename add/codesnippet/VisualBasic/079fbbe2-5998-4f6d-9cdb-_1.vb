        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions
        Dim test As Boolean = True

        ' This expression represents the conditional block.
        Dim ifThenExpr As Expression = Expression.IfThen(
             Expression.Constant(test),
             Expression.Call(
                 Nothing,
                 GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                 Expression.Constant("The condition is true.")
             )
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(ifThenExpr).Compile()()

        ' This code example produces the following output:
        '
        ' The condition is true.