Public Class DemoSorting
    Sub Method1()
        '<code>
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
        '</code>
    End Sub
End Class
