         // Adds an array of CodeCommentStatement objects to the collection.
         array<CodeCommentStatement^>^comments = {gcnew CodeCommentStatement( "Test comment" ),gcnew CodeCommentStatement( "Another test comment" )};
         collection->AddRange( comments );
         
         // Adds a collection of CodeCommentStatement objects to the collection.
         CodeCommentStatementCollection^ commentsCollection = gcnew CodeCommentStatementCollection;
         commentsCollection->Add( gcnew CodeCommentStatement( "Test comment" ) );
         commentsCollection->Add( gcnew CodeCommentStatement( "Another test comment" ) );
         collection->AddRange( commentsCollection );