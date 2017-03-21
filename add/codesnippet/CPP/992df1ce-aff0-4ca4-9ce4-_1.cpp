         // Open or create a writable file, no larger than 10k
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,FileAccess::Write,FileShare::Write,10240,isoFile );
         