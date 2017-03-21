            string tree1 = "maple";
            string tree2 = "oak";

            System.Reflection.MethodInfo addMethod = typeof(Dictionary<int, string>).GetMethod("Add");

            // Create two ElementInit objects that represent the
            // two key-value pairs to add to the Dictionary.
            System.Linq.Expressions.ElementInit elementInit1 =
                System.Linq.Expressions.Expression.ElementInit(
                    addMethod,
                    System.Linq.Expressions.Expression.Constant(tree1.Length),
                    System.Linq.Expressions.Expression.Constant(tree1));
            System.Linq.Expressions.ElementInit elementInit2 =
                System.Linq.Expressions.Expression.ElementInit(
                    addMethod,
                    System.Linq.Expressions.Expression.Constant(tree2.Length),
                    System.Linq.Expressions.Expression.Constant(tree2));

            // Create a NewExpression that represents constructing
            // a new instance of Dictionary<int, string>.
            System.Linq.Expressions.NewExpression newDictionaryExpression =
                System.Linq.Expressions.Expression.New(typeof(Dictionary<int, string>));

            // Create a ListInitExpression that represents initializing
            // a new Dictionary<> instance with two key-value pairs.
            System.Linq.Expressions.ListInitExpression listInitExpression =
                System.Linq.Expressions.Expression.ListInit(
                    newDictionaryExpression,
                    elementInit1,
                    elementInit2);

            Console.WriteLine(listInitExpression.ToString());

            // This code produces the following output:
            //
            // new Dictionary`2() {Void Add(Int32, System.String)(5,"maple"),
            // Void Add(Int32, System.String)(3,"oak")}