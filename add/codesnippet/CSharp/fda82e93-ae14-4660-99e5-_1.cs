            // Adds an array of CodeTypeReference objects to the collection.
            CodeTypeReference[] references = { new CodeTypeReference(typeof(bool)), new CodeTypeReference(typeof(bool)) };
            collection.AddRange( references );

            // Adds a collection of CodeTypeReference objects to the collection.
            CodeTypeReferenceCollection referencesCollection = new CodeTypeReferenceCollection();
            referencesCollection.Add( new CodeTypeReference(typeof(bool)) );
            referencesCollection.Add( new CodeTypeReference(typeof(bool)) );
            collection.AddRange( referencesCollection );