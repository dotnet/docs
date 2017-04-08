
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesStringDictionary
    Public Shared Sub Main()
        ' <Snippet2>
        Dim myCollection As New StringDictionary()
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class

