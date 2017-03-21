            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This parameter expression represents a variable that will hold the array.
            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[]), "Array");

            // This parameter expression represents an array index.            
            ParameterExpression indexExpr = Expression.Parameter(typeof(int), "Index");

            // This parameter represents the value that will be added to a corresponding array element.
            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            // This expression represents an array access operation.
            // It can be used for assigning to, or reading from, an array element.
            Expression arrayAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexExpr
            );

            // This lambda expression assigns a value provided to it to a specified array element.
            // The array, the index of the array element, and the value to be added to the element
            // are parameters of the lambda expression.
            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                arrayExpr,
                indexExpr,
                valueExpr
            );

            // Print out expressions.
            Console.WriteLine("Array Access Expression:");
            Console.WriteLine(arrayAccessExpr.ToString());

            Console.WriteLine("Lambda Expression:");
            Console.WriteLine(lambdaExpr.ToString());

            Console.WriteLine("The result of executing the lambda expression:");

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            // Parameters passed to the Invoke method are passed to the lambda expression.
            Console.WriteLine(lambdaExpr.Compile().Invoke(new int[] { 10, 20, 30 }, 0, 5));

            // This code example produces the following output:
            //
            // Array Access Expression:
            // Array[Index]

            // Lambda Expression:
            // (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            // The result of executing the lambda expression:
            // 15
