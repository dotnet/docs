        Dim TestString As String = "apple    pear banana  "
        Dim TestArray() As String = Split(TestString)
        ' TestArray holds {"apple", "", "", "", "pear", "banana", "", ""}
        Dim LastNonEmpty As Integer = -1
        For i As Integer = 0 To TestArray.Length - 1
            If TestArray(i) <> "" Then
                LastNonEmpty += 1
                TestArray(LastNonEmpty) = TestArray(i)
            End If
        Next
        ReDim Preserve TestArray(LastNonEmpty)
        ' TestArray now holds {"apple", "pear", "banana"}