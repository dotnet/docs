            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // A label that is used by a break statement and a loop. 
            LabelTarget breakLabel = Expression.Label();

            // A label that is used by the Continue statement and the loop it refers to.
            LabelTarget continueLabel = Expression.Label();

            // This expression represents a Continue statement.
            Expression continueExpr = Expression.Continue(continueLabel);

            // A variable that triggers the exit from the loop.
            ParameterExpression count = Expression.Parameter(typeof(int));

            // A loop statement.
            Expression loopExpr = Expression.Loop(
                Expression.Block(
                    Expression.IfThen(
                        Expression.GreaterThan(count, Expression.Constant(3)),
                        Expression.Break(breakLabel)
                    ),
                    Expression.PreIncrementAssign(count),
                    Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("Loop")
                            ),
                    continueExpr,
                    Expression.PreDecrementAssign(count)
                ),
                breakLabel,
                continueLabel
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            // Without the Continue statement, the loop would go on forever.
            Expression.Lambda<Action<int>>(loopExpr, count).Compile()(1);

            // This code example produces the following output:
            //
            // Loop
            // Loop
            // Loop