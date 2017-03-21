        // Create a collection derived from NameObjectCollectionBase
        ICollection myCollection = new DerivedCollection();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }