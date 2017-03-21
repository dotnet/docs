        // Create a collection derived from NameObjectCollectionBase
        NameObjectCollectionBase myBaseCollection = new DerivedCollection();
        // Get the ICollection from NameObjectCollectionBase.KeysCollection
        ICollection myKeysCollection = myBaseCollection.Keys;
        lock(myKeysCollection.SyncRoot)
        {
            foreach (object item in myKeysCollection)
            {
                // Insert your code here.
            }
        }