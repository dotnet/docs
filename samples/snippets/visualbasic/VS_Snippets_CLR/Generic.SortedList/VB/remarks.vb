Imports System
Imports System.Collections.Generic

Public Class Example
    Public Shared Sub Main()
        ' Create a new sorted list of strings, with string
        ' keys.
        Dim mySortedList As New SortedList(Of Integer, String)()

        ' Add some elements to the list. There are no
        ' duplicate keys, but some of the values are duplicates.
        mySortedList.Add(0, "notepad.exe")
        mySortedList.Add(1, "paint.exe")
        mySortedList.Add(2, "paint.exe")
        mySortedList.Add(3, "wordpad.exe")

        '<Snippet11>
        Dim v As String = mySortedList.Values(3)
        '</Snippet11>

        Console.WriteLine("Value at index 3: {0}", v)

        '<Snippet12>
        For Each kvp As KeyValuePair(Of Integer, String) In mySortedList
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value)
        Next kvp
        '</Snippet12>
    End Sub
End Class