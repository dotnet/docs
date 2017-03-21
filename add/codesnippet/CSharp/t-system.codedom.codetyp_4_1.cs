            // Creates an empty CodeTypeReferenceCollection.
            CodeTypeReferenceCollection collection = new CodeTypeReferenceCollection();
            
            // Adds a CodeTypeReference to the collection.
            collection.Add( new CodeTypeReference(typeof(bool)) );

            // Adds an array of CodeTypeReference objects to the collection.
            CodeTypeReference[] references = { new CodeTypeReference(typeof(bool)), new CodeTypeReference(typeof(bool)) };
            collection.AddRange( references );

            // Adds a collection of CodeTypeReference objects to the collection.
            CodeTypeReferenceCollection referencesCollection = new CodeTypeReferenceCollection();
            referencesCollection.Add( new CodeTypeReference(typeof(bool)) );
            referencesCollection.Add( new CodeTypeReference(typeof(bool)) );
            collection.AddRange( referencesCollection );

            // Tests for the presence of a CodeTypeReference in the 
            // collection, and retrieves its index if it is found.
            CodeTypeReference testReference = new CodeTypeReference(typeof(bool));
            int itemIndex = -1;
            if( collection.Contains( testReference ) )
                itemIndex = collection.IndexOf( testReference );

            // Copies the contents of the collection, beginning at index 0, 
            // to the specified CodeTypeReference array.
            // 'references' is a CodeTypeReference array.
            collection.CopyTo( references, 0 );

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a CodeTypeReference at index 0 of the collection.
            collection.Insert( 0, new CodeTypeReference(typeof(bool)) );

            // Removes the specified CodeTypeReference from the collection.
            CodeTypeReference reference = new CodeTypeReference(typeof(bool));
            collection.Remove( reference );

            // Removes the CodeTypeReference at index 0.
            collection.RemoveAt(0);