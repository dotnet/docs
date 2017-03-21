            List<System.Linq.Expressions.Expression> trees =
                new List<System.Linq.Expressions.Expression>()
                    { System.Linq.Expressions.Expression.Constant("oak"),
                      System.Linq.Expressions.Expression.Constant("fir"),
                      System.Linq.Expressions.Expression.Constant("spruce"),
                      System.Linq.Expressions.Expression.Constant("alder") };

            // Create an expression tree that represents creating and  
            // initializing a one-dimensional array of type string.
            System.Linq.Expressions.NewArrayExpression newArrayExpression =
                System.Linq.Expressions.Expression.NewArrayInit(typeof(string), trees);

            // Output the string representation of the Expression.
            Console.WriteLine(newArrayExpression.ToString());

            // This code produces the following output:
            //
            // new [] {"oak", "fir", "spruce", "alder"}