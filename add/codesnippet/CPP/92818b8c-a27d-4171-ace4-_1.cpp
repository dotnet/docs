      // Tests for the presence of a CompilerError in the
      // collection, and retrieves its index if it is found.
      CompilerError^ testError = gcnew CompilerError( "Testfile.cs",5,10,"CS0001","Example error text" );
      int itemIndex = -1;
      if ( collection->Contains( testError ) )
         itemIndex = collection->IndexOf( testError );