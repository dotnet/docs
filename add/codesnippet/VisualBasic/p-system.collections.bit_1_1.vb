        Dim myCollection As New BitArray(64, true)
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next item
        End SyncLock