        ' String to search in.
        Dim SearchString As String = "XXpXXpXXPXXP"
        ' Search for "P".
        Dim SearchChar As String = "P"

        Dim TestPos As Integer
        ' A textual comparison starting at position 4. Returns 6.
        TestPos = InStr(4, SearchString, SearchChar, CompareMethod.Text)

        ' A binary comparison starting at position 1. Returns 9.
        TestPos = InStr(1, SearchString, SearchChar, CompareMethod.Binary)

        ' If Option Compare is not set, or set to Binary, return 9.
        ' If Option Compare is set to Text, returns 3.
        TestPos = InStr(SearchString, SearchChar)

        ' Returns 0.
        TestPos = InStr(1, SearchString, "W")