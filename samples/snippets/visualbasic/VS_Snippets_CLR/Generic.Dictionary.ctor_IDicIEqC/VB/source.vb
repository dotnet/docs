' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new sorted dictionary of strings, with string 
        ' keys and a case-insensitive comparer.
        Dim openWith As New SortedDictionary(Of String, String)( _
            StringComparer.CurrentCultureIgnoreCase)
        
        ' Add some elements to the sorted dictionary. 
        openWith.Add("txt", "notepad.exe")
        openWith.Add("Bmp", "paint.exe")
        openWith.Add("DIB", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' Create a Dictionary of strings with string keys and a 
        ' case-insensitive equality comparer, and initialize it
        ' with the contents of the sorted dictionary.
        Dim copy As New Dictionary(Of String, String)(openWith, _
            StringComparer.CurrentCultureIgnoreCase)

        ' List the contents of the copy.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In copy
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp

    End Sub

End Class

' This code example produces the following output:
'
'Key = Bmp, Value = paint.exe
'Key = DIB, Value = paint.exe
'Key = rtf, Value = wordpad.exe
'Key = txt, Value = notepad.exe
'</Snippet1>
