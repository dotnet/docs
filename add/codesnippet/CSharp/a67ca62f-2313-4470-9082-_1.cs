            // Add the following directive to the file:
            // using System.Linq.Expressions;  
            bool test = true;

            // This expression represents the conditional block.
            Expression ifThenElseExpr = Expression.IfThenElse(
                Expression.Constant(test),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("The condition is true.")
                ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("The condition is false.")
                )
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(ifThenElseExpr).Compile()();

            // This code example produces the following output:
            //
            // The condition is true.