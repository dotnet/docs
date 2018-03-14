
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class HybridDictSample
    Public Shared Sub Main()
        ' Creates and initializes a new HybridDictionary.
        Dim myHybridDictionary As New HybridDictionary()

        ' <snippet2>
        For Each de In myHybridDictionary
            '...
        Next
        ' </snippet2>

        ' <snippet3>
        Dim myCollection As New HybridDictionary()
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next
        End SyncLock
        ' </snippet3>
    End Sub
End Class
