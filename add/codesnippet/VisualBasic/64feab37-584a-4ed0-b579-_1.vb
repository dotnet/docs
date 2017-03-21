        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions

        ' An expression that represents the switch value.
        Dim switchValue As ConstantExpression = Expression.Constant(3)

        ' This expression represents a switch statement 
        ' that has a default case.
        Dim switchExpr As SwitchExpression =
        Expression.Switch(
            switchValue,
            Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("Default")
                    ),
            New SwitchCase() {
                Expression.SwitchCase(
                    Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("First")
                    ),
                    Expression.Constant(1)
                ),
                Expression.SwitchCase(
                    Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("Second")
                    ),
                    Expression.Constant(2)
                )
            }
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(switchExpr).Compile()()

        ' This code example produces the following output:
        '
        ' Default