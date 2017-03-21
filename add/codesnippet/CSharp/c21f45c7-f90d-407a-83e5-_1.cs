            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            // Convert the List to an IQueryable<int>.
            IQueryable<int> iqueryable = grades.AsQueryable();

            // Get the Expression property of the IQueryable object.
            System.Linq.Expressions.Expression expressionTree =
                iqueryable.Expression;

            Console.WriteLine("The NodeType of the expression tree is: "
                + expressionTree.NodeType.ToString());
            Console.WriteLine("The Type of the expression tree is: "
                + expressionTree.Type.Name);

            /*
                This code produces the following output:

                The NodeType of the expression tree is: Constant
                The Type of the expression tree is: EnumerableQuery`1
            */