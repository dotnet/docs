         IsolatedStorageFile^ isoFile;
         isoFile = IsolatedStorageFile::GetUserStoreForDomain();
         
         // Open or create a writable file.
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,FileAccess::Write,isoFile );
         StreamWriter^ writer = gcnew StreamWriter( isoStream );
         writer->WriteLine( this->NewsUrl );
         writer->WriteLine( this->SportsUrl );
         
         // Calculate the amount of space used to record the user's preferences.
         double d = isoFile->CurrentSize / isoFile->MaximumSize;
         Console::WriteLine( "CurrentSize = {0}", isoFile->CurrentSize.ToString() );
         Console::WriteLine( "MaximumSize = {0}", isoFile->MaximumSize.ToString() );
         writer->Close();
         isoFile->Close();
         isoStream->Close();
         return d;
         