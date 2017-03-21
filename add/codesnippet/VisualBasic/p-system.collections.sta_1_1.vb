        Dim myCollection As New Stack()

        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock