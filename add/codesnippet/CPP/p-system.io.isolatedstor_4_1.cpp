   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   bool GetPrefsForUser()
   {
      try
      {
         
         // Retrieve an IsolatedStorageFile for the current Domain and Assembly.
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), (Type^)nullptr, nullptr );
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::Open,FileAccess::ReadWrite,isoFile );
         
         // farThe code executes to this point only if a file corresponding to the username exists.
         // Though you can perform operations on the stream, you cannot get a handle to the file.
         try
         {
            IntPtr aFileHandle = isoStream->Handle;
            Console::WriteLine( "A pointer to a file handle has been obtained. {0} {1}", aFileHandle, aFileHandle.GetHashCode() );
         }
         catch ( Exception^ e ) 
         {
            
            // Handle the exception.
            Console::WriteLine( "Expected exception" );
            Console::WriteLine( e->ToString() );
         }

         StreamReader^ reader = gcnew StreamReader( isoStream );
         
         // Read the data.
         this->NewsUrl = reader->ReadLine();
         this->SportsUrl = reader->ReadLine();
         reader->Close();
         isoFile->Close();
         isoStream->Close();
         return false;
      }
      catch ( Exception^ e ) 
      {
         
         // Expected exception if a file cannot be found. This indicates that we have a new user.
         String^ errorMessage = e->ToString();
         return true;
      }

   }

