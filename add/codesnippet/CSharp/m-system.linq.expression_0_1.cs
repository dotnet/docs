            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents the default value of a type
            // (0 for integer, null for a string, etc.)
            Expression defaultExpr = Expression.Default(
                                        typeof(byte)
                                    );

            // Print out the expression.
            Console.WriteLine(defaultExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<byte>>(defaultExpr).Compile()());

            // This code example produces the following output:
            //
            // default(Byte)
            // 0