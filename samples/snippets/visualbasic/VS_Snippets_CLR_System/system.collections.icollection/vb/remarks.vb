Imports System
Imports System.Collections

Public Class Remarks
    Public Shared Sub Main()
        Dim someCollection As New ArrayList(5)
        ' <Snippet1>
        Dim myCollection As ICollection = someCollection
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet1>
    End Sub

    Public Shared Sub Dummy()
        Dim someCollection As New ArrayList(5)
        ' <Snippet2>
        Dim myCollection As ICollection = someCollection
        SyncLock myCollection.SyncRoot
            ' Some operation on the collection, which is now thread safe.
        End SyncLock
        ' </Snippet2>
    End Sub
End Class




