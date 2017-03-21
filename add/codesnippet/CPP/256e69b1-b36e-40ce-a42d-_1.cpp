      // Adds an array of CompilerError objects to the collection.
      array<CompilerError^>^errors = {gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ),gcnew CompilerError( "Testfile::cs",5,10,"CS0001","Example error text" )};
      collection->AddRange( errors );
      
      // Adds a collection of CompilerError objects to the collection.
      CompilerErrorCollection^ errorsCollection = gcnew CompilerErrorCollection;
      errorsCollection->Add( gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ) );
      errorsCollection->Add( gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" ) );
      collection->AddRange( errorsCollection );