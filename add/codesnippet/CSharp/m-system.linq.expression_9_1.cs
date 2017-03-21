            // Create a NewExpression that represents constructing
            // a new instance of Dictionary<int, string>.
            System.Linq.Expressions.NewExpression newDictionaryExpression =
                System.Linq.Expressions.Expression.New(typeof(Dictionary<int, string>));

            Console.WriteLine(newDictionaryExpression.ToString());

            // This code produces the following output:
            //
            // new Dictionary`2()