         // Creates an empty CodeCatchClauseCollection.
         CodeCatchClauseCollection^ collection = gcnew CodeCatchClauseCollection;

         // Adds a CodeCatchClause to the collection.
         collection->Add( gcnew CodeCatchClause( "e" ) );

         // Adds an array of CodeCatchClause objects to the collection.
         array<CodeCatchClause^>^clauses = {gcnew CodeCatchClause,gcnew CodeCatchClause};
         collection->AddRange( clauses );

         // Adds a collection of CodeCatchClause objects to the collection.
         CodeCatchClauseCollection^ clausesCollection = gcnew CodeCatchClauseCollection;
         clausesCollection->Add( gcnew CodeCatchClause( "e",gcnew CodeTypeReference( System::ArgumentOutOfRangeException::typeid ) ) );
         clausesCollection->Add( gcnew CodeCatchClause( "e" ) );
         collection->AddRange( clausesCollection );

         // Tests for the presence of a CodeCatchClause in the 
         // collection, and retrieves its index if it is found.
         CodeCatchClause^ testClause = gcnew CodeCatchClause( "e" );
         int itemIndex = -1;
         if ( collection->Contains( testClause ) )
            itemIndex = collection->IndexOf( testClause );

         // Copies the contents of the collection beginning at index 0 to the specified CodeCatchClause array.
         // 'clauses' is a CodeCatchClause array.
         collection->CopyTo( clauses, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeCatchClause at index 0 of the collection.
         collection->Insert( 0, gcnew CodeCatchClause( "e" ) );

         // Removes the specified CodeCatchClause from the collection.
         CodeCatchClause^ clause = gcnew CodeCatchClause( "e" );
         collection->Remove( clause );

         // Removes the CodeCatchClause at index 0.
         collection->RemoveAt( 0 );