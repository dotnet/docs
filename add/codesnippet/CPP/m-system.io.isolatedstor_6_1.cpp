   // This method deletes directories in the specified Isolated Storage, after first 
   // deleting the files they contain. In this example, the Archive directory is deleted. 
   // There should be no other directories in this Isolated Storage.
   void DeleteDirectories()
   {
      try
      {
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
         array<String^>^dirNames = isoFile->GetDirectoryNames( "*" );
         array<String^>^fileNames = isoFile->GetFileNames( "Archive\\*" );
         
         // Delete the current files within the Archive directory.
         if ( fileNames->Length > 0 )
         {
            for ( int i = 0; i < fileNames->Length; ++i )
            {
               
               //delete files
               isoFile->DeleteFile( String::Concat("Archive\\", fileNames[ i ]) );

            }
            fileNames = isoFile->GetFileNames( "Archive\\*" );
         }
         if ( dirNames->Length > 0 )
         {
            for ( int i = 0; i < dirNames->Length; ++i )
            {
               
               // Delete the Archive directory.
               isoFile->DeleteDirectory( dirNames[ i ] );

            }
         }
         dirNames = isoFile->GetDirectoryNames( "*" );
         isoFile->Remove();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }

   }

