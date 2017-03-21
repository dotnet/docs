        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' A label that is used by a break statement and a loop. 
        Dim breakLabel As LabelTarget = Expression.Label()

        ' A label that is used by the Continue statement and the loop it refers to.
        Dim continueLabel As LabelTarget = Expression.Label()

        ' This expression represents a Continue statement.
        Dim continueExpr As Expression = Expression.Continue(continueLabel)

        ' A variable that triggers the exit from the loop.
        Dim count As ParameterExpression = Expression.Parameter(GetType(Integer))

        ' A loop statement.
        Dim loopExpr As Expression = Expression.Loop(
               Expression.Block(
                   Expression.IfThen(
                       Expression.GreaterThan(count, Expression.Constant(3)),
                       Expression.Break(breakLabel)
                   ),
                   Expression.PreIncrementAssign(count),
                   Expression.Call(
                               Nothing,
                               GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                               Expression.Constant("Loop")
                           ),
                   continueExpr,
                   Expression.PreDecrementAssign(count)
               ),
               breakLabel,
               continueLabel
           )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        ' Without the Continue statement, the loop would go on forever.
        Expression.Lambda(Of Action(Of Integer))(loopExpr, count).Compile()(1)

        ' This code example produces the following output:
        '
        ' Loop
        ' Loop
        ' Loop