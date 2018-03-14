Imports System
Imports System.Collections

Public Class SamplesSortedList
    Public Shared Sub Main()
        ' Creates and initializes a new SortedList.
        Dim mySortedList As New SortedList()
        mySortedList.Add("Third", "!")
        mySortedList.Add("Second", "World")
        mySortedList.Add("First", "Hello")

        ' <Snippet2>
        For Each de As DictionaryEntry In mySortedList
            '...
        Next de
        ' </Snippet2>
    End Sub
End Class
