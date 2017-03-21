         // Retrieve an IsolatedStorageFile for the current Domain and Assembly.
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), (Type^)nullptr, nullptr );
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::Open,FileAccess::ReadWrite,isoFile );
         