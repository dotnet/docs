        Dim OneString As String
        Dim TwoString As String
        OneString = "one, two, three, four, five"
        ' Evaluates to "two".
        TwoString = OneString.Substring(5, 3)
        OneString = "1"
        ' Evaluates to "11".
        TwoString = OneString & "1"