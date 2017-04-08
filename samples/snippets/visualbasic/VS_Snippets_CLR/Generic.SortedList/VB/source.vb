' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        '<Snippet2>
        ' Create a new sorted list of strings, with string 
        ' keys. 
        Dim openWith As New SortedList(Of String, String)
        
        ' Add some elements to the list. There are no 
        ' duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' The Add method throws an exception if the new key is 
        ' already in the list.
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
        ' key is not in the list.
        Try
            Console.WriteLine("For key = ""tif"", value = {0}.", _
                openWith("tif"))
        Catch 
            Console.WriteLine("Key = ""tif"" is not found.")
        End Try
        '</Snippet4>

        '<Snippet5>
        ' When a program often has to try keys that turn out not to
        ' be in the list, TryGetValue can be a more efficient 
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
        ' When you use foreach to enumerate list elements,
        ' the elements are retrieved as KeyValuePair objects.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp
        '</Snippet7>

        '<Snippet8>
        ' To get the values alone, use the Values property.
        Dim ilistValues As IList(Of String) = openWith.Values
        
        ' The elements of the list are strongly typed with the
        ' type that was specified for the SortedList values.
        Console.WriteLine()
        For Each s As String In ilistValues
            Console.WriteLine("Value = {0}", s)
        Next s

        ' The Values property is an efficient way to retrieve
        ' values by index.
        Console.WriteLine(vbLf & "Indexed retrieval using the " & _
            "Values property: Values(2) = {0}", openWith.Values(2))
        '</Snippet8>

        '<Snippet9>
        ' To get the keys alone, use the Keys property.
        Dim ilistKeys As IList(Of String) = openWith.Keys
        
        ' The elements of the list are strongly typed with the
        ' type that was specified for the SortedList keys.
        Console.WriteLine()
        For Each s As String In ilistKeys 
            Console.WriteLine("Key = {0}", s)
        Next s

        ' The Keys property is an efficient way to retrieve
        ' keys by index.
        Console.WriteLine(vbLf & "Indexed retrieval using the " & _
            "Keys property: Keys(2) = {0}", openWith.Keys(2))
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
'Key = bmp, Value = paint.exe
'Key = dib, Value = paint.exe
'Key = doc, Value = winword.exe
'Key = ht, Value = hypertrm.exe
'Key = rtf, Value = winword.exe
'Key = txt, Value = notepad.exe
'
'Value = paint.exe
'Value = paint.exe
'Value = winword.exe
'Value = hypertrm.exe
'Value = winword.exe
'Value = notepad.exe
'
'Indexed retrieval using the Values property: Values(2) = winword.exe
'
'Key = bmp
'Key = dib
'Key = doc
'Key = ht
'Key = rtf
'Key = txt
'
'Indexed retrieval using the Keys property: Keys(2) = doc
'
'Remove("doc")
'Key "doc" is not found.
' 
'</Snippet1>
