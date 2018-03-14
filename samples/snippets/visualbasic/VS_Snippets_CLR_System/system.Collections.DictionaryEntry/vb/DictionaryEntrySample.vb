'<snippet00>
'A simple example for the DictionaryEntry structure.
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

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

        ' When you use For Each to enumerate hash table elements,
        ' the elements are retrieved as DictionaryEntry objects.
        Console.WriteLine()
        '<snippet01>
        For Each de As DictionaryEntry In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                de.Key, de.Value)
        Next de
        '</snippet01>

    End Sub

End Module

' This code example produces output similar to the following:
'
'Key = rtf, Value = wordpad.exe
'Key = txt, Value = notepad.exe
'Key = dib, Value = paint.exe
'Key = bmp, Value = paint.exe
'</snippet00>