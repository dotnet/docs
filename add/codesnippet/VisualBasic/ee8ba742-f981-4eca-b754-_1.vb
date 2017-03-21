        Dim TestString As String = "the quick brown fox jumps over the lazy dog"
        Dim TestNumber As Integer
        ' Returns 32.
        TestNumber = InStrRev(TestString, "the")
        ' Returns 1.
        TestNumber = InStrRev(TestString, "the", 16)