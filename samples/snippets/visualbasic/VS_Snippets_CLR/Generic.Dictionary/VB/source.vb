' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        '<Snippet2>
        ' Create a new dictionary of strings, with string keys.
        '
        Dim openWith As New Dictionary(Of String, String)
        
        ' Add some elements to the dictionary. There are no 
        ' duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' The Add method throws an exception if the new key is 
        ' already in the dictionary.
        Try
            openWith.Add("txt", "winword.exe")
        Catch 
            Console.WriteLine("An element with Key = ""txt"" already exists.")
        End Try
        '</Snippet2>

        '<Snippet3>
        ' The Item property is the default property, so you 
        ' can omit its name when accessing elements. 
        Console.WriteLine("For key = ""rtf"", value = {0}.", _
            openWith("rtf"))
        
        ' The default Item property can be used to change the value
        ' associated with a key.
        openWith("rtf") = "winword.exe"
        Console.WriteLine("For key = ""rtf"", value = {0}.", _
            openWith("rtf"))
        
        ' If a key does not exist, setting the default Item property
        ' for that key adds a new key/value pair.
        openWith("doc") = "winword.exe"
        '</Snippet3>

        '<Snippet4>
        ' The default Item property throws an exception if the requested
        ' key is not in the dictionary.
        Try
            Console.WriteLine("For key = ""tif"", value = {0}.", _
                openWith("tif"))
        Catch 
            Console.WriteLine("Key = ""tif"" is not found.")
        End Try
        '</Snippet4>

        '<Snippet5>
        ' When a program often has to try keys that turn out not to
        ' be in the dictionary, TryGetValue can be a more efficient 
        ' way to retrieve values.
        Dim value As String = ""
        If openWith.TryGetValue("tif", value) Then
            Console.WriteLine("For key = ""tif"", value = {0}.", value)
        Else
            Console.WriteLine("Key = ""tif"" is not found.")
        End If
        '</Snippet5>

        '<Snippet6>
        ' ContainsKey can be used to test keys before inserting 
        ' them.
        If Not openWith.ContainsKey("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", _
                openWith("ht"))
        End If
        '</Snippet6>

        '<Snippet7>
        ' When you use foreach to enumerate dictionary elements,
        ' the elements are retrieved as KeyValuePair objects.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp
        '</Snippet7>

        '<Snippet8>
        ' To get the values alone, use the Values property.
        Dim valueColl As _
            Dictionary(Of String, String).ValueCollection = _
            openWith.Values
        
        ' The elements of the ValueCollection are strongly typed
        ' with the type that was specified for dictionary values.
        Console.WriteLine()
        For Each s As String In  valueColl
            Console.WriteLine("Value = {0}", s)
        Next s
        '</Snippet8>

        '<Snippet9>
        ' To get the keys alone, use the Keys property.
        Dim keyColl As _
            Dictionary(Of String, String).KeyCollection = _
            openWith.Keys
        
        ' The elements of the KeyCollection are strongly typed
        ' with the type that was specified for dictionary keys.
        Console.WriteLine()
        For Each s As String In  keyColl
            Console.WriteLine("Key = {0}", s)
        Next s
        '</Snippet9>

        '<Snippet10>
        ' Use the Remove method to remove a key/value pair.
        Console.WriteLine(vbLf + "Remove(""doc"")")
        openWith.Remove("doc")
        
        If Not openWith.ContainsKey("doc") Then
            Console.WriteLine("Key ""doc"" is not found.")
        End If
        '</Snippet10>

    End Sub

End Class

' This code example produces the following output:
'
'An element with Key = "txt" already exists.
'For key = "rtf", value = wordpad.exe.
'For key = "rtf", value = winword.exe.
'Key = "tif" is not found.
'Key = "tif" is not found.
'Value added for key = "ht": hypertrm.exe
'
'Key = txt, Value = notepad.exe
'Key = bmp, Value = paint.exe
'Key = dib, Value = paint.exe
'Key = rtf, Value = winword.exe
'Key = doc, Value = winword.exe
'Key = ht, Value = hypertrm.exe
'
'Value = notepad.exe
'Value = paint.exe
'Value = paint.exe
'Value = winword.exe
'Value = winword.exe
'Value = hypertrm.exe
'
'Key = txt
'Key = bmp
'Key = dib
'Key = rtf
'Key = doc
'Key = ht
'
'Remove("doc")
'Key "doc" is not found.
' 
'</Snippet1>
