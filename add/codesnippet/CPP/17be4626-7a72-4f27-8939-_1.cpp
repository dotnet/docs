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