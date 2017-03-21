            // Creates an empty CodeNamespaceCollection.            
            CodeNamespaceCollection collection = new CodeNamespaceCollection();
            
            // Adds a CodeNamespace to the collection.
            collection.Add( new CodeNamespace("TestNamespace") );

            // Adds an array of CodeNamespace objects to the collection.
            CodeNamespace[] namespaces = { new CodeNamespace("TestNamespace1"), new CodeNamespace("TestNamespace2") };
            collection.AddRange( namespaces );

            // Adds a collection of CodeNamespace objects to the collection.
            CodeNamespaceCollection namespacesCollection = new CodeNamespaceCollection();
            namespacesCollection.Add( new CodeNamespace("TestNamespace1") );
            namespacesCollection.Add( new CodeNamespace("TestNamespace2") );
            collection.AddRange( namespacesCollection );

            // Tests for the presence of a CodeNamespace in the collection,
            // and retrieves its index if it is found.
            CodeNamespace testNamespace = new CodeNamespace("TestNamespace");
            int itemIndex = -1;
            if( collection.Contains( testNamespace ) )
                itemIndex = collection.IndexOf( testNamespace );

            // Copies the contents of the collection beginning at index 0,
            // to the specified CodeNamespace array.
            // 'namespaces' is a CodeNamespace array.
            collection.CopyTo( namespaces, 0 );

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a CodeNamespace at index 0 of the collection.
            collection.Insert( 0, new CodeNamespace("TestNamespace") );

            // Removes the specified CodeNamespace from the collection.
            CodeNamespace namespace_ = new CodeNamespace("TestNamespace");
            collection.Remove( namespace_ );

            // Removes the CodeNamespace at index 0.
            collection.RemoveAt(0);