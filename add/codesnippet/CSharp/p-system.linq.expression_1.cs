            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            ConstantExpression constExpr = Expression.Constant(5);
            Console.WriteLine("NodeType: " + constExpr.NodeType);
            Console.WriteLine("Type: " + constExpr.Type);

            BinaryExpression binExpr = Expression.Add(constExpr, constExpr);
            Console.WriteLine("NodeType: " + binExpr.NodeType);
            Console.WriteLine("Type: " + binExpr.Type);

            // This code example produces the following output:
            //
            // NodeType: Constant
            // Type: System.Int32
            // NodeType: Add
            // Type: System.Int32