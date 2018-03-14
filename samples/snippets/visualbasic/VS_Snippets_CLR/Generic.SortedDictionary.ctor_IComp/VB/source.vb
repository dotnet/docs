' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new SortedDictionary of strings, with string keys 
        ' and a case-insensitive comparer for the current culture.
        Dim openWith As New SortedDictionary(Of String, String)( _
            StringComparer.CurrentCultureIgnoreCase)
        
        ' Add some elements to the dictionary. 
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("DIB", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")

        ' Try to add a fifth element with a key that is the same 
        ' except for case; this would be allowed with the default
        ' comparer.
        Try
            openWith.Add("BMP", "paint.exe")
        Catch ex As ArgumentException
            Console.WriteLine(vbLf & "BMP is already in the dictionary.")
        End Try
        
        ' List the contents of the sorted dictionary.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp

    End Sub

End Class

' This code example produces the following output:
'
'BMP is already in the dictionary.
'
'Key = bmp, Value = paint.exe
'Key = DIB, Value = paint.exe
'Key = rtf, Value = wordpad.exe
'Key = txt, Value = notepad.exe
'</Snippet1>
