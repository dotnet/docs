            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a Constant value.
            Expression constantExpr = Expression.Constant(5.5);

            // Print out the expression.
            Console.WriteLine(constantExpr.ToString());

            // You can also use variables.
            double num = 3.5;
            constantExpr = Expression.Constant(num);
            Console.WriteLine(constantExpr.ToString());

            // This code example produces the following output:
            //
            // 5.5
            // 3.5