        ' Create a collection derived from NameObjectCollectionBase
        Dim myBaseCollection As NameObjectCollectionBase = New DerivedCollection()
        ' Get the ICollection from NameObjectCollectionBase.KeysCollection
        Dim myKeysCollection As ICollection = myBaseCollection.Keys
        SyncLock myKeysCollection.SyncRoot
            For Each item As Object In myKeysCollection
                ' Insert your code here.
            Next item
        End SyncLock