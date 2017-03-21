            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // A label expression of the void type that is the target for Expression.Return().
            LabelTarget returnTarget = Expression.Label();

            // This block contains a GotoExpression that represents a return statement with no value.
            // It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
            // The types of the GotoExpression, label expression, and LabelTarget must match.
            BlockExpression blockExpr =
                Expression.Block(
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Return")),
                    Expression.Return(returnTarget),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Other Work")),
                    Expression.Label(returnTarget)
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(blockExpr).Compile()();

            // This code example produces the following output:
            //
            // Return

            // "Other Work" is not printed because 
            // the Return expression transfers execution from Expression.Return(returnTarget)
            // to Expression.Label(returnTarget).