        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Assembly |
            IsolatedStorageScope::Domain | IsolatedStorageScope::User,
            (Type^)nullptr, (Type^)nullptr);