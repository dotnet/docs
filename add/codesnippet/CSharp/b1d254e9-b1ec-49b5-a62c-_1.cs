            string tree = "maple";

            System.Reflection.MethodInfo addMethod = typeof(Dictionary<int, string>).GetMethod("Add");

            // Create an ElementInit that represents calling
            // Dictionary<int, string>.Add(tree.Length, tree).
            System.Linq.Expressions.ElementInit elementInit =
                System.Linq.Expressions.Expression.ElementInit(
                    addMethod,
                    System.Linq.Expressions.Expression.Constant(tree.Length),
                    System.Linq.Expressions.Expression.Constant(tree));

            Console.WriteLine(elementInit.ToString());

            // This code produces the following output:
            //
            // Void Add(Int32, System.String)(5,"maple")