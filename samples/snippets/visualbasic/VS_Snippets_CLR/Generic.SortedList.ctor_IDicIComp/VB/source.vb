' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new Dictionary of strings, with string keys and
        ' a case-insensitive equality comparer for the current 
        ' culture.
        Dim openWith As New Dictionary(Of String, String)( _
            StringComparer.CurrentCultureIgnoreCase)
        
        ' Add some elements to the dictionary. 
        openWith.Add("txt", "notepad.exe")
        openWith.Add("Bmp", "paint.exe")
        openWith.Add("DIB", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' Create a SortedList of strings with string keys and a 
        ' case-insensitive equality comparer for the current culture,
        ' and initialize it with the contents of the Dictionary.
        Dim copy As New SortedList(Of String, String)(openWith, _
            StringComparer.CurrentCultureIgnoreCase)

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
'Key = Bmp, Value = paint.exe
'Key = DIB, Value = paint.exe
'Key = rtf, Value = wordpad.exe
'Key = txt, Value = notepad.exe
'</Snippet1>
