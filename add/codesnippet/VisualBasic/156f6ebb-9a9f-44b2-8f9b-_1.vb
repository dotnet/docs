Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new dictionary of strings, with string keys,
        ' and access it using the IDictionary interface.
        '
        Dim openWith As IDictionary = _
            New Dictionary(Of String, String)
        
        ' Add some elements to the dictionary. There are no 
        ' duplicate keys, but some of the values are duplicates.
        ' IDictionary.Add throws an exception if incorrect types
        ' are supplied for key or value.
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        Try
            openWith.Add(42, New Example())
        Catch ex As ArgumentException
            Console.WriteLine("An exception was caught for " & _
                "IDictionary.Add. Exception message:" & vbLf _
                & vbTab & ex.Message & vbLf)
        End Try
        
        ' The Add method throws an exception if the new key is 
        ' already in the dictionary.
        Try
            openWith.Add("txt", "winword.exe")
        Catch 
            Console.WriteLine("An element with Key = ""txt"" already exists.")
        End Try

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

        ' The default Item property returns Nothing if the key
        ' is of the wrong data type.
        Console.WriteLine("The default Item property returns Nothing" _
            & " if the key is of the wrong type:")
        Console.WriteLine("For key = 2, value = {0}.", _
            openWith(2))

        ' The default Item property throws an exception when setting
        ' a value if the key is of the wrong data type.
        Try
            openWith(2) = "This does not get added."
        Catch 
            Console.WriteLine("A key of the wrong type was specified" _
                & " when setting the default Item property.")
        End Try

        ' Unlike the default Item property on the Dictionary class
        ' itself, IDictionary.Item does not throw an exception
        ' if the requested key is not in the dictionary.
        Console.WriteLine("For key = ""tif"", value = {0}.", _
            openWith("tif"))

        ' Contains can be used to test keys before inserting 
        ' them.
        If Not openWith.Contains("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", _
                openWith("ht"))
        End If

        ' IDictionary.Contains returns False if the wrong data 
        ' type is supplied.
        Console.WriteLine("openWith.Contains(29.7) returns {0}", _
            openWith.Contains(29.7))

        ' When you use foreach to enumerate dictionary elements
        ' with the IDictionary interface, the elements are retrieved
        ' as DictionaryEntry objects instead of KeyValuePair objects.
        Console.WriteLine()
        For Each de As DictionaryEntry In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                de.Key, de.Value)
        Next 

        ' To get the values alone, use the Values property.
        Dim icoll As ICollection = openWith.Values
        
        ' The elements of the collection are strongly typed
        ' with the type that was specified for dictionary values,
        ' even though the ICollection interface is not strongly
        ' typed.
        Console.WriteLine()
        For Each s As String In  icoll
            Console.WriteLine("Value = {0}", s)
        Next s

        ' To get the keys alone, use the Keys property.
        icoll = openWith.Keys
        
        ' The elements of the collection are strongly typed
        ' with the type that was specified for dictionary keys,
        ' even though the ICollection interface is not strongly
        ' typed.
        Console.WriteLine()
        For Each s As String In  icoll
            Console.WriteLine("Key = {0}", s)
        Next s

        ' Use the Remove method to remove a key/value pair. No
        ' exception is thrown if the wrong data type is supplied.
        Console.WriteLine(vbLf + "Remove(""dib"")")
        openWith.Remove("dib")
        
        If Not openWith.Contains("dib") Then
            Console.WriteLine("Key ""dib"" is not found.")
        End If

    End Sub

End Class

' This code example produces the following output:
'
'An exception was caught for IDictionary.Add. Exception message:
'        The value "42" is not of type "System.String" and cannot be used in this generic collection.
'Parameter name: key
'
'An element with Key = "txt" already exists.
'For key = "rtf", value = wordpad.exe.
'For key = "rtf", value = winword.exe.
'The default Item property returns Nothing if the key is of the wrong type:
'For key = 2, value = .
'A key of the wrong type was specified when setting the default Item property.
'For key = "tif", value = .
'Value added for key = "ht": hypertrm.exe
'openWith.Contains(29.7) returns False
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
'Remove("dib")
'Key "dib" is not found.
' 