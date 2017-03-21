            // Adds an array of CodeAttributeArgument objects to the collection.
            CodeAttributeArgument[] arguments = { new CodeAttributeArgument(), new CodeAttributeArgument() };
            collection.AddRange( arguments );

            // Adds a collection of CodeAttributeArgument objects to 
            // the collection.
            CodeAttributeArgumentCollection argumentsCollection = new CodeAttributeArgumentCollection();
            argumentsCollection.Add( new CodeAttributeArgument("TestBooleanArgument", new CodePrimitiveExpression(true)) );
            argumentsCollection.Add( new CodeAttributeArgument("TestIntArgument", new CodePrimitiveExpression(1)) );
            collection.AddRange( argumentsCollection );