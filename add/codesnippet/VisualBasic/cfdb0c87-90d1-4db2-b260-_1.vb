        ' Create a collection derived from NameObjectCollectionBase
        Dim myCollection As ICollection = New DerivedCollection()
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock