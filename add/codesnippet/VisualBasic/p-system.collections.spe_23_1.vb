        Dim myCollection As New StringCollection()
        SyncLock myCollection.SyncRoot
            For Each item as Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock