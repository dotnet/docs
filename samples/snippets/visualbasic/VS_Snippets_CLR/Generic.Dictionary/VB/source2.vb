Imports System
Imports System.Collections.Generic

Public Class Example
    Public Shared Sub Main()
        ' Create a new dictionary of strings, with string keys.
        '
        Dim myDictionary As New Dictionary(Of String, String)

        ' Add some elements to the dictionary. There are no
        ' duplicate keys, but some of the values are duplicates.
        myDictionary.Add("txt", "notepad.exe")
        myDictionary.Add("bmp", "paint.exe")
        myDictionary.Add("dib", "paint.exe")
        myDictionary.Add("rtf", "wordpad.exe")

        ' <Snippet11>
        For Each kvp As KeyValuePair(Of String, String) In myDictionary
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value)
        Next kvp
        ' </Snippet11>
    End Sub
End Class

