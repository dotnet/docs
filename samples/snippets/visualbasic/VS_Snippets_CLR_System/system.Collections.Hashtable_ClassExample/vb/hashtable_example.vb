'<snippet00>
Imports System
Imports System.Collections

Module Example

    Sub Main()

        ' Create a new hash table.
        '
        Dim openWith As New Hashtable()

        ' Add some elements to the hash table. There are no 
        ' duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")

        ' The Add method throws an exception if the new key is 
        ' already in the hash table.
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

        ' ContainsKey can be used to test keys before inserting 
        ' them.
        If Not openWith.ContainsKey("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", _
                openWith("ht"))
        End If

        ' When you use foreach to enumerate hash table elements,
        ' the elements are retrieved as KeyValuePair objects.
        Console.WriteLine()
        For Each de As DictionaryEntry In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                de.Key, de.Value)
        Next de

        ' To get the values alone, use the Values property.
        Dim valueColl As ICollection = openWith.Values

        ' The elements of the ValueCollection are strongly typed
        ' with the type that was specified for hash table values.
        Console.WriteLine()
        For Each s As String In valueColl
            Console.WriteLine("Value = {0}", s)
        Next s

        ' To get the keys alone, use the Keys property.
        Dim keyColl As ICollection = openWith.Keys

        ' The elements of the KeyCollection are strongly typed
        ' with the type that was specified for hash table keys.
        Console.WriteLine()
        For Each s As String In keyColl
            Console.WriteLine("Key = {0}", s)
        Next s

        ' Use the Remove method to remove a key/value pair.
        Console.WriteLine(vbLf + "Remove(""doc"")")
        openWith.Remove("doc")

        If Not openWith.ContainsKey("doc") Then
            Console.WriteLine("Key ""doc"" is not found.")
        End If

    End Sub

End Module

' This code example produces the following output:
'
'An element with Key = "txt" already exists.
'For key = "rtf", value = wordpad.exe.
'For key = "rtf", value = winword.exe.
'Value added for key = "ht": hypertrm.exe
'
'Key = dib, Value = paint.exe
'Key = txt, Value = notepad.exe
'Key = ht, Value = hypertrm.exe
'Key = bmp, Value = paint.exe
'Key = rtf, Value = winword.exe
'Key = doc, Value = winword.exe
'
'Value = paint.exe
'Value = notepad.exe
'Value = hypertrm.exe
'Value = paint.exe
'Value = winword.exe
'Value = winword.exe
'
'Key = dib
'Key = txt
'Key = ht
'Key = bmp
'Key = rtf
'Key = doc
'
'Remove("doc")
'Key "doc" is not found.
'</snippet00>