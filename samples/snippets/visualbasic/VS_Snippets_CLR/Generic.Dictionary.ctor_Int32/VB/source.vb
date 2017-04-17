' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new dictionary of strings, with string keys and
        ' an initial capacity of 4.
        Dim openWith As New Dictionary(Of String, String)(4)
        
        ' Add 4 elements to the dictionary. 
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' List the contents of the dictionary.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp

    End Sub

End Class

' This code example produces the following output:
'
'Key = txt, Value = notepad.exe
'Key = bmp, Value = paint.exe
'Key = dib, Value = paint.exe
'Key = rtf, Value = wordpad.exe
'</Snippet1>
