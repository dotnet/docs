      // Creates an empty CompilerErrorCollection.
      CompilerErrorCollection^ collection = gcnew CompilerErrorCollection;

      // Adds a CompilerError to the collection.
      collection->Add( gcnew CompilerError( "Testfile::cs",5,10,"CS0001","Example error text" ) );

      // Adds an array of CompilerError objects to the collection.
      array<CompilerError^>^errors = {gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ),gcnew CompilerError( "Testfile::cs",5,10,"CS0001","Example error text" )};
      collection->AddRange( errors );
      
      // Adds a collection of CompilerError objects to the collection.
      CompilerErrorCollection^ errorsCollection = gcnew CompilerErrorCollection;
      errorsCollection->Add( gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ) );
      errorsCollection->Add( gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ) );
      collection->AddRange( errorsCollection );

      // Tests for the presence of a CompilerError in the
      // collection, and retrieves its index if it is found.
      CompilerError^ testError = gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" );
      int itemIndex = -1;
      if ( collection->Contains( testError ) )
         itemIndex = collection->IndexOf( testError );

      // Copies the contents of the collection, beginning at index 0,
      // to the specified CompilerError array.
      // 'errors' is a CompilerError array.
      collection->CopyTo( errors, 0 );

      // Retrieves the count of the items in the collection.
      int collectionCount = collection->Count;

      // Inserts a CompilerError at index 0 of the collection.
      collection->Insert( 0, gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ) );

      // Removes the specified CompilerError from the collection.
      CompilerError^ error = gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" );
      collection->Remove( error );

      // Removes the CompilerError at index 0.
      collection->RemoveAt( 0 );