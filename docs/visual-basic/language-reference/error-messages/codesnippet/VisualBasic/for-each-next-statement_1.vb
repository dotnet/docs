        ' Create a list of strings by using a
        ' collection initializer.
        Dim lst As New List(Of String) _
            From {"abc", "def", "ghi"}

        ' Iterate through the list.
        For Each item As String In lst
            Debug.Write(item & " ")
        Next
        Debug.WriteLine("")
        'Output: abc def ghi