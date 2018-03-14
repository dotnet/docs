' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new dictionary of strings, with string keys, and
        ' access it through the generic ICollection interface. The
        ' generic ICollection interface views the dictionary as a
        ' collection of KeyValuePair objects with the same type
        ' arguments as the dictionary.
        '
        Dim openWith As ICollection(Of KeyValuePair(Of String, String)) _
            = New Dictionary(Of String, String)
        
        ' Add some elements to the dictionary. When elements are 
        ' added through the ICollection(Of T) interface, the keys
        ' and values must be wrapped in KeyValuePair objects.
        '
        openWith.Add(New KeyValuePair(Of String,String)("txt", "notepad.exe"))
        openWith.Add(New KeyValuePair(Of String,String)("bmp", "paint.exe"))
        openWith.Add(New KeyValuePair(Of String,String)("dib", "paint.exe"))
        openWith.Add(New KeyValuePair(Of String,String)("rtf", "wordpad.exe"))
        
        Console.WriteLine()
        For Each element As KeyValuePair(Of String, String) in openWith
            Console.WriteLine("{0}, {1}", element.Key, element.Value)
        Next
           
        ' The Contains method also takes a KeyValuePair object.
        '
        Console.WriteLine(vbLf & _
            "Contains(KeyValuePair(""txt"", ""notepad.exe"")): {0}", _
            openWith.Contains(New KeyValuePair(Of String,String)("txt", "notepad.exe")))

        ' The Remove method takes a KeyValuePair object.)
        '
        ' Use the Remove method to remove a key/value pair.
        Console.WriteLine(vbLf &  _
            "Remove(New KeyValuePair(""dib"", ""paint.exe""))")
        openWith.Remove(New KeyValuePair(Of String,String)("dib", "paint.exe"))
        
        Console.WriteLine()
        For Each element As KeyValuePair(Of String, String) in openWith
            Console.WriteLine("{0}, {1}", element.Key, element.Value)
        Next

        ' Create an array of KeyValuePair objects and copy the 
        ' contents of the dictionary to it. Subtract one from the
        ' array size because Visual Basic allocates an extra array
        ' element.
        Dim copy(openWith.Count - 1) As KeyValuePair(Of String, String)
        openWith.CopyTo(copy, 0)
    
        ' List the contents of the array.
        '
        Console.WriteLine()
        For Each element As KeyValuePair(Of String, String) in copy
            Console.WriteLine("{0}, {1}", element.Key, element.Value)
        Next

    End Sub

End Class

' This code example produces the following output:
'
'txt, notepad.exe
'bmp, paint.exe
'dib, paint.exe
'rtf, wordpad.exe
'
'Contains(KeyValuePair("txt", "notepad.exe")): True
'
'Remove(New KeyValuePair("dib", "paint.exe"))
'
'txt, notepad.exe
'bmp, paint.exe
'rtf, wordpad.exe
'
'txt, notepad.exe
'bmp, paint.exe
'rtf, wordpad.exe 
'</Snippet1>
