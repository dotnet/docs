            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents an exclusive OR operation for its two arguments.
            // Both arguments must be of the same type, 
            // which can be either integer or boolean.

            Expression exclusiveOrExpr = Expression.ExclusiveOr(
                Expression.Constant(5),
                Expression.Constant(3)
            );

            // Print out the expression.
            Console.WriteLine(exclusiveOrExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.           
            Console.WriteLine(
                Expression.Lambda<Func<int>>(exclusiveOrExpr).Compile()());

            // The XOR operation is performed as follows:
            // 101 xor 011 = 110

            // This code example produces the following output:
            //
            // (5 ^ 3)
            // 6