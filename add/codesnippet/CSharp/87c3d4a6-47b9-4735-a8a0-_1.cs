        // Get the ICollection interface from the ReadOnlyCollectionBase
        // derived class.
        ICollection myCollection = myReadOnlyCollection;
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }