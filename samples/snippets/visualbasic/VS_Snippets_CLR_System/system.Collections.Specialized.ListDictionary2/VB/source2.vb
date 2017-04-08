
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesListDictionary
    Public Shared Sub Main()
        ' <Snippet2>
        Dim myCollection As New ListDictionary()
        SyncLock myCollection.SyncRoot
            For Each item as Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub

    Public Shared Sub Dummy()
        Dim myListDictionary As New ListDictionary()
        ' <Snippet3>
        For Each de As DictionaryEntry In myListDictionary
            '...
        Next de
        ' </Snippet3>
    End Sub
End Class

