   void DeleteFiles()
   {
      
      try
      {
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
         array<String^>^dirNames = isoFile->GetDirectoryNames( "*" );
         array<String^>^fileNames = isoFile->GetFileNames( "*" );
         
         // List the files currently in this Isolated Storage.
         // The list represents all users who have personal
         // preferences stored for this application.
         if ( fileNames->Length > 0 )
         {
            for ( int i = 0; i < fileNames->Length; ++i )
            {
               
               //Delete the files.
               isoFile->DeleteFile( fileNames[ i ] );

            }
            fileNames = isoFile->GetFileNames( "*" );
         }
         isoFile->Close();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }

   }

