
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class OrderedDictionarySample
    Public Shared Sub Main()
        Dim myOrderedDictionary As New OrderedDictionary()
        ' <Snippet06>
        For Each de As DictionaryEntry In myOrderedDictionary
            '...
        Next de
        ' </Snippet06>
    End Sub
End Class

