Imports System
Imports System.Collections

Public Class SamplesLocker

    Public Shared Sub Main()
        ' <Snippet2>
        Dim myCollection As New BitArray(64, true)
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class



