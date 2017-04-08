Imports System
Imports System.Collections

Public Class Remarks
    Public Shared Sub Main()
        ' Create a new hash table.
        '
        Dim myHashtable As New Hashtable()

        ' Add some elements to the hash table. There are no
        ' duplicate keys, but some of the values are duplicates.
        myHashtable.Add("txt", "notepad.exe")
        myHashtable.Add("bmp", "paint.exe")
        myHashtable.Add("dib", "paint.exe")
        myHashtable.Add("rtf", "wordpad.exe")


        ' When you use foreach to enumerate hash table elements,
        ' the elements are retrieved as KeyValuePair objects.
        ' <snippet01>
        For Each de As DictionaryEntry In myHashtable
            ' ...
        Next de
        ' </snippet01>
    End Sub
End Class


