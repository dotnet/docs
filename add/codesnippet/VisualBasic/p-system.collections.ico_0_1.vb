        Dim myCollection As ICollection = someCollection
        SyncLock myCollection.SyncRoot
            ' Some operation on the collection, which is now thread safe.
        End SyncLock