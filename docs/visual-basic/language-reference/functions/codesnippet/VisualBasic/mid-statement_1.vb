        Dim TestString As String
        ' Initializes string.
        TestString = "The dog jumps"
        ' Returns "The fox jumps".
        Mid(TestString, 5, 3) = "fox"
        ' Returns "The cow jumps".
        Mid(TestString, 5) = "cow"
        ' Returns "The cow jumpe".
        Mid(TestString, 5) = "cow jumped over"
        ' Returns "The duc jumpe".
        Mid(TestString, 5, 3) = "duck"