
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesStringCollection
    Public Shared Sub Main()
        ' <Snippet2>
        Dim myCollection As New StringCollection()
        SyncLock myCollection.SyncRoot
            For Each item as Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class