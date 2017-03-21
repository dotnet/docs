        ' Get the ICollection interface from the CollectionBase
        ' derived class.
        Dim myCollection As ICollection = myCollectionBase
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock