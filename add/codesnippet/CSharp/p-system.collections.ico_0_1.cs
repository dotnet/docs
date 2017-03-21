        ICollection myCollection = someCollection;
        lock(myCollection.SyncRoot)
        {
            // Some operation on the collection, which is now thread safe.
        }