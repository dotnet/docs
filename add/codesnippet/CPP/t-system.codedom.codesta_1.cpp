         // Creates an empty CodeStatementCollection.
         CodeStatementCollection^ collection = gcnew CodeStatementCollection;

         // Adds a CodeStatement to the collection.
         collection->Add( gcnew CodeCommentStatement( "Test comment statement" ) );

         // Adds an array of CodeStatement objects to the collection.
         array<CodeStatement^>^statements = {gcnew CodeCommentStatement( "Test comment statement" ),gcnew CodeCommentStatement( "Test comment statement" )};
         collection->AddRange( statements );

         // Adds a collection of CodeStatement objects to the collection.
         CodeStatement^ testStatement = gcnew CodeCommentStatement( "Test comment statement" );
         CodeStatementCollection^ statementsCollection = gcnew CodeStatementCollection;
         statementsCollection->Add( gcnew CodeCommentStatement( "Test comment statement" ) );
         statementsCollection->Add( gcnew CodeCommentStatement( "Test comment statement" ) );
         statementsCollection->Add( testStatement );
         collection->AddRange( statementsCollection );

         // Tests for the presence of a CodeStatement in the 
         // collection, and retrieves its index if it is found.
         int itemIndex = -1;
         if ( collection->Contains( testStatement ) )
            itemIndex = collection->IndexOf( testStatement );

         // Copies the contents of the collection beginning at index 0 to the specified CodeStatement array.
         // 'statements' is a CodeStatement array.
         collection->CopyTo( statements, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeStatement at index 0 of the collection.
         collection->Insert( 0, gcnew CodeCommentStatement( "Test comment statement" ) );

         // Removes the specified CodeStatement from the collection.
         collection->Remove( testStatement );

         // Removes the CodeStatement at index 0.
         collection->RemoveAt( 0 );