Imports System
Imports System.Collections.Generic

Public Class Example
    Public Shared Sub Main()
        ' Create a new dictionary of strings, with string keys.
        '
        Dim exDictionary As New Dictionary(Of Integer, String)

        ' Add some elements to the dictionary. There are no
        ' duplicate keys, but some of the values are duplicates.
        exDictionary.Add(0, "notepad.exe")
        exDictionary.Add(1, "paint.exe")
        exDictionary.Add(2, "paint.exe")
        exDictionary.Add(3, "wordpad.exe")
        Dim myDictionary As IDictionary(Of Integer, String) = exDictionary
        ' <Snippet11>
        For Each kvp As KeyValuePair(Of Integer, String) In myDictionary
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value)
        Next kvp
        ' </Snippet11>
    End Sub
End Class

