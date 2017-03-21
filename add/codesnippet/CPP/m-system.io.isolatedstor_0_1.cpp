        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Assembly |
            IsolatedStorageScope::Domain | IsolatedStorageScope::Machine,
            (Type^)nullptr, (Type^)nullptr);