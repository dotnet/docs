        Dim myCollection As New ListDictionary()
        SyncLock myCollection.SyncRoot
            For Each item as Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock