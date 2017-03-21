            // Tests for the presence of a CodeAttributeArgument 
            // within the collection, and retrieves its index if it is found.
            CodeAttributeArgument testArgument = new CodeAttributeArgument("Test Boolean Argument", new CodePrimitiveExpression(true));
            int itemIndex = -1;
            if( collection.Contains( testArgument ) )
                itemIndex = collection.IndexOf( testArgument );