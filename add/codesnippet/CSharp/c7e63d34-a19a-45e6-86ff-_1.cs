            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // An expression that represents the switch value.
            ConstantExpression switchValue = Expression.Constant(2);

            // This expression represents a switch statement 
            // without a default case.
            SwitchExpression switchExpr =
                Expression.Switch(
                    switchValue,
                    new SwitchCase[] {
                        Expression.SwitchCase(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("First")
                            ),
                            Expression.Constant(1)
                        ),
                        Expression.SwitchCase(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("Second")
                            ),
                            Expression.Constant(2)
                        )
                    }
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(switchExpr).Compile()();

            // This code example produces the following output:
            //
            // Second