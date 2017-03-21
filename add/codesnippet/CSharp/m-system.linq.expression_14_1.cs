            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a constant value, 
            // for which you can explicitly specify the type. 
            // This can be used, for example, for defining constants of a nullable type.
            Expression constantExpr = Expression.Constant(
                                        null,
                                        typeof(double?)
                                    );

            // Print out the expression.
            Console.WriteLine(constantExpr.ToString());

            // This code example produces the following output:
            //
            // null
