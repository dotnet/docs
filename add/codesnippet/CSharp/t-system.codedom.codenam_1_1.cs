            // Creates an empty CodeNamespaceImportCollection.
            CodeNamespaceImportCollection collection = 
                new CodeNamespaceImportCollection();            			

            // Adds a CodeNamespaceImport to the collection.
            collection.Add( new CodeNamespaceImport("System") );

            // Adds an array of CodeNamespaceImport objects to the collection.
            CodeNamespaceImport[] Imports = { 
                    new CodeNamespaceImport("System"),
                    new CodeNamespaceImport("System.Drawing") };
            collection.AddRange( Imports );
            
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;