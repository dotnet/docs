         // Creates an empty CodeNamespaceCollection.            
         CodeNamespaceCollection^ collection = gcnew CodeNamespaceCollection;

         // Adds a CodeNamespace to the collection.
         collection->Add( gcnew CodeNamespace( "TestNamespace" ) );

         // Adds an array of CodeNamespace objects to the collection.
         array<CodeNamespace^>^namespaces = {gcnew CodeNamespace( "TestNamespace1" ),gcnew CodeNamespace( "TestNamespace2" )};
         collection->AddRange( namespaces );

         // Adds a collection of CodeNamespace objects to the collection.
         CodeNamespaceCollection^ namespacesCollection = gcnew CodeNamespaceCollection;
         namespacesCollection->Add( gcnew CodeNamespace( "TestNamespace1" ) );
         namespacesCollection->Add( gcnew CodeNamespace( "TestNamespace2" ) );
         collection->AddRange( namespacesCollection );

         // Tests for the presence of a CodeNamespace in the collection,
         // and retrieves its index if it is found.
         CodeNamespace^ testNamespace = gcnew CodeNamespace( "TestNamespace" );
         int itemIndex = -1;
         if ( collection->Contains( testNamespace ) )
            itemIndex = collection->IndexOf( testNamespace );

         // Copies the contents of the collection beginning at index 0,
         // to the specified CodeNamespace array.
         // 'namespaces' is a CodeNamespace array.
         collection->CopyTo( namespaces, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeNamespace at index 0 of the collection.
         collection->Insert( 0, gcnew CodeNamespace( "TestNamespace" ) );

         // Removes the specified CodeNamespace from the collection.
         CodeNamespace^ namespace_ = gcnew CodeNamespace( "TestNamespace" );
         collection->Remove( namespace_ );

         // Removes the CodeNamespace at index 0.
         collection->RemoveAt( 0 );