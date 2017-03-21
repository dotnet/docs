      array<String^>^dirNames = isoFile->GetDirectoryNames( "*" );
      array<String^>^fileNames = isoFile->GetFileNames( "*" );
      
      // List directories currently in this Isolated Storage.
      if ( dirNames->Length > 0 )
      {
         for ( int i = 0; i < dirNames->Length; ++i )
         {
            Console::WriteLine( "Directory Name: {0}", dirNames[ i ] );

         }
      }

      
      // List the files currently in this Isolated Storage.
      // The list represents all users who have personal preferences stored for this application.
      if ( fileNames->Length > 0 )
      {
         for ( int i = 0; i < fileNames->Length; ++i )
         {
            Console::WriteLine( "File Name: {0}", fileNames[ i ] );

         }
      }

      