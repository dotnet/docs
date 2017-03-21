        class Animal
        {
            public string species;
        }

        public static void CreateFieldExpression()
        {
            Animal horse = new Animal();

            // Create a MemberExpression that represents getting
            // the value of the 'species' field of class 'Animal'.
            System.Linq.Expressions.MemberExpression memberExpression =
                System.Linq.Expressions.Expression.Field(
                    System.Linq.Expressions.Expression.Constant(horse),
                    "species");

            Console.WriteLine(memberExpression.ToString());

            // This code produces the following output:
            //
            // value(CodeSnippets.FieldExample+Animal).species
        }