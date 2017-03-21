        ' Get the ICollection interface from the ReadOnlyCollectionBase
        ' derived class.
        Dim myCollection As ICollection = myReadOnlyCollection
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock