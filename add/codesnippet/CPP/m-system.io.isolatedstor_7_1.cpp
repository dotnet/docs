   double SetNewPrefsForUser()
   {
      try
      {
         Byte inputChar;
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
         
         // If this is not a new user, archive the old preferences and 
         // overwrite them using the new preferences.
         if (  !this->NewPrefs )
         {
            if ( isoFile->GetDirectoryNames( "Archive" )->Length == 0 )
                        isoFile->CreateDirectory( "Archive" );
            else
            {
               
               // This is the stream to which data will be written.
               IsolatedStorageFileStream^ source = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,isoFile );
               
               // This is the stream from which data will be read.
               Console::WriteLine( "Is the source file readable?  {0}", (source->CanRead ? (String^)"true" : "false") );
               Console::WriteLine( "Creating new IsolatedStorageFileStream for Archive." );
               
               // Open or create a writable file.
               IsolatedStorageFileStream^ target = gcnew IsolatedStorageFileStream( String::Concat("Archive\\",this->userName),FileMode::OpenOrCreate,FileAccess::Write,FileShare::Write,isoFile );
               
               Console::WriteLine( "Is the target file writable? {0}", (target->CanWrite ? (String^)"true" : "false") );
               
               // Stream the old file to a new file in the Archive directory.
               if ( source->IsAsync && target->IsAsync )
               {
                  
                  // IsolatedStorageFileStreams cannot be asynchronous.  However, you
                  // can use the asynchronous BeginRead and BeginWrite functions
                  // with some possible performance penalty.
                  Console::WriteLine( "IsolatedStorageFileStreams cannot be asynchronous." );
               }
               else
               {
                  
                  Console::WriteLine( "Writing data to the new file." );
                  while ( source->Position < source->Length )
                  {
                     inputChar = (Byte)source->ReadByte();
                     target->WriteByte( (Byte)source->ReadByte() );
                  }
                  
                  // Determine the size of the IsolatedStorageFileStream
                  // by checking its Length property.
                  Console::WriteLine( "Total Bytes Read: {0}", source->Length.ToString() );
                  
               }
               
               // After you have read and written to the streams, close them.
               target->Close();
               source->Close();
            }
         }
         
         // Open or create a writable file, no larger than 10k
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,FileAccess::Write,FileShare::Write,10240,isoFile );
         
         isoStream->Position = 0; // Position to overwrite the old data.
         