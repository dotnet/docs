        // Get the ICollection interface from the CollectionBase
        // derived class.
        ICollection myCollection = myCollectionBase;
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }