               // This is the stream to which data will be written.
               IsolatedStorageFileStream^ source = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,isoFile );
               
               // This is the stream from which data will be read.
               Console::WriteLine( "Is the source file readable?  {0}", (source->CanRead ? (String^)"true" : "false") );
               Console::WriteLine( "Creating new IsolatedStorageFileStream for Archive." );
               
               // Open or create a writable file.
               IsolatedStorageFileStream^ target = gcnew IsolatedStorageFileStream( String::Concat("Archive\\",this->userName),FileMode::OpenOrCreate,FileAccess::Write,FileShare::Write,isoFile );
               