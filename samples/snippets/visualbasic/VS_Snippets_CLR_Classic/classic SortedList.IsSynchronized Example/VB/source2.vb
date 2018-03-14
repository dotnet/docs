Imports System
Imports System.Collections

Public Class SamplesSortedList
    Public Shared Sub Main()
        ' <Snippet2>
        Dim myCollection As New SortedList()
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class

