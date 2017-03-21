            // Adds an array of CodeTypeDeclaration objects to the collection.
            CodeTypeDeclaration[] declarations = { new CodeTypeDeclaration("TestType1"), new CodeTypeDeclaration("TestType2") };
            collection.AddRange( declarations );

            // Adds a collection of CodeTypeDeclaration objects to the 
            // collection.
            CodeTypeDeclarationCollection declarationsCollection = new CodeTypeDeclarationCollection();
            declarationsCollection.Add( new CodeTypeDeclaration("TestType1") );
            declarationsCollection.Add( new CodeTypeDeclaration("TestType2") );
            collection.AddRange( declarationsCollection );