         // Creates an empty CodeTypeReferenceCollection.
         CodeTypeReferenceCollection^ collection = gcnew CodeTypeReferenceCollection;

         // Adds a CodeTypeReference to the collection.
         collection->Add( gcnew CodeTypeReference( bool::typeid ) );

         // Adds an array of CodeTypeReference objects to the collection.
         array<CodeTypeReference^>^references = {gcnew CodeTypeReference( bool::typeid ),gcnew CodeTypeReference( bool::typeid )};
         collection->AddRange( references );
         
         // Adds a collection of CodeTypeReference objects to the collection.
         CodeTypeReferenceCollection^ referencesCollection = gcnew CodeTypeReferenceCollection;
         referencesCollection->Add( gcnew CodeTypeReference( bool::typeid ) );
         referencesCollection->Add( gcnew CodeTypeReference( bool::typeid ) );
         collection->AddRange( referencesCollection );

         // Tests for the presence of a CodeTypeReference in the 
         // collection, and retrieves its index if it is found.
         CodeTypeReference^ testReference = gcnew CodeTypeReference( bool::typeid );
         int itemIndex = -1;
         if ( collection->Contains( testReference ) )
            itemIndex = collection->IndexOf( testReference );

         // Copies the contents of the collection, beginning at index 0, 
         // to the specified CodeTypeReference array.
         // 'references' is a CodeTypeReference array.
         collection->CopyTo( references, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeTypeReference at index 0 of the collection.
         collection->Insert( 0, gcnew CodeTypeReference( bool::typeid ) );

         // Removes the specified CodeTypeReference from the collection.
         CodeTypeReference^ reference = gcnew CodeTypeReference( bool::typeid );
         collection->Remove( reference );

         // Removes the CodeTypeReference at index 0.
         collection->RemoveAt( 0 );