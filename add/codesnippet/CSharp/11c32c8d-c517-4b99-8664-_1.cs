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