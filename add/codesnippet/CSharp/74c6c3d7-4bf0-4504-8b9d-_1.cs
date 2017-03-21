            // Tests for the presence of a CodeAttributeDeclaration in 
            // the collection, and retrieves its index if it is found.
            CodeAttributeDeclaration testdeclaration = new CodeAttributeDeclaration("DescriptionAttribute", new CodeAttributeArgument(new CodePrimitiveExpression("Test Description")) );
            int itemIndex = -1;
            if( collection.Contains( testdeclaration ) )
                itemIndex = collection.IndexOf( testdeclaration );