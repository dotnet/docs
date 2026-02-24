Imports System

Module Program
    Sub Main(args As String())
        ' Words to sort
        Dim values As String() = {"able", "ångström", "apple", "Æble",
                                  "Windows", "Visual Studio"}

        '
        ' Potentially incorrect code - behavior might vary based on locale.
        '
        Dim mySet As New SortedSet(Of String)(values) ' No comparer specified

        Dim list As New List(Of String)(values)
        list.Sort() ' No comparer specified

        '
        ' Corrected code - uses ordinal sorting; doesn't vary by locale.
        '
        Dim mySet2 As New SortedSet(Of String)(values, StringComparer.Ordinal)

        Dim list2 As New List(Of String)(values)
        list2.Sort(StringComparer.Ordinal)
    End Sub
End Module
