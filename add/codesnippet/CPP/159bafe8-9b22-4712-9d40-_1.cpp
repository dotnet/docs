        // Create a collection derived from NameObjectCollectionBase
        NameObjectCollectionBase^ myBaseCollection = gcnew DerivedCollection();
        // Get the ICollection from NameObjectCollectionBase.KeysCollection
        ICollection^ myKeysCollection = myBaseCollection->Keys;
        bool lockTaken = false;
        try
        {
            Monitor::Enter(myKeysCollection->SyncRoot, lockTaken);
            for each (Object^ item in myKeysCollection)
            {
                // Insert your code here.
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor::Exit(myKeysCollection->SyncRoot);
            }
        }