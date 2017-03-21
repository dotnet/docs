        Dim myCollection As ICollection = New ShortStringDictionary()
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next item
        End SyncLock