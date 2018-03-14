' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new Dictionary of strings, with string 
        ' keys.
        Dim openWith As New Dictionary(Of String, String)
        
        ' Add some elements to the dictionary. 
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' Create a SortedDictionary of strings with string keys, 
        ' and initialize it with the contents of the Dictionary.
        Dim copy As New SortedDictionary(Of String, String)(openWith)

        ' List the sorted contents of the copy.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In copy
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp

    End Sub

End Class

' This code example produces the following output:
'
'Key = bmp, Value = paint.exe
'Key = dib, Value = paint.exe
'Key = rtf, Value = wordpad.exe
'Key = txt, Value = notepad.exe
'</Snippet1>
