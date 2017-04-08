Imports System
Imports System.Collections

Public Class SamplesHashtable
    
    Public Shared Sub Main()
        ' <Snippet2>
        Dim myCollection As New Hashtable()
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next
        End SyncLock
        ' </Snippet2>
    End Sub
End Class

