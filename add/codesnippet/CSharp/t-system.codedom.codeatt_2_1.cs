            // Creates an empty CodeAttributeDeclarationCollection.
            CodeAttributeDeclarationCollection collection = new CodeAttributeDeclarationCollection();

            // Adds a CodeAttributeDeclaration to the collection.
            collection.Add( new CodeAttributeDeclaration("DescriptionAttribute",  new CodeAttributeArgument(new CodePrimitiveExpression("Test Description"))) );

            // Adds an array of CodeAttributeDeclaration objects 
            // to the collection.
            CodeAttributeDeclaration[] declarations = { new CodeAttributeDeclaration(), new CodeAttributeDeclaration() };
            collection.AddRange( declarations );

            // Adds a collection of CodeAttributeDeclaration objects 
            // to the collection.
            CodeAttributeDeclarationCollection declarationsCollection = new CodeAttributeDeclarationCollection();
            declarationsCollection.Add( new CodeAttributeDeclaration("DescriptionAttribute", new CodeAttributeArgument(new CodePrimitiveExpression("Test Description"))) );
            declarationsCollection.Add( new CodeAttributeDeclaration("BrowsableAttribute", new CodeAttributeArgument(new CodePrimitiveExpression(true))) );
            collection.AddRange( declarationsCollection );

            // Tests for the presence of a CodeAttributeDeclaration in 
            // the collection, and retrieves its index if it is found.
            CodeAttributeDeclaration testdeclaration = new CodeAttributeDeclaration("DescriptionAttribute", new CodeAttributeArgument(new CodePrimitiveExpression("Test Description")) );
            int itemIndex = -1;
            if( collection.Contains( testdeclaration ) )
                itemIndex = collection.IndexOf( testdeclaration );

            // Copies the contents of the collection, beginning at index 0,
            // to the specified CodeAttributeDeclaration array.
            // 'declarations' is a CodeAttributeDeclaration array.
            collection.CopyTo( declarations, 0 );

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a CodeAttributeDeclaration at index 0 of the collection.
            collection.Insert( 0, new CodeAttributeDeclaration("DescriptionAttribute", new CodeAttributeArgument(new CodePrimitiveExpression("Test Description"))) );

            // Removes the specified CodeAttributeDeclaration from 
            // the collection.
            CodeAttributeDeclaration declaration = new CodeAttributeDeclaration("DescriptionAttribute", new CodeAttributeArgument(new CodePrimitiveExpression("Test Description")) );
            collection.Remove( declaration );

            // Removes the CodeAttributeDeclaration at index 0.
            collection.RemoveAt(0);