        ' Initializes string.
        Dim TestString As String = "  <-Trim->  "
        Dim TrimString As String
        ' Returns "<-Trim->  ".
        TrimString = LTrim(TestString)
        ' Returns "  <-Trim->".
        TrimString = RTrim(TestString)
        ' Returns "<-Trim->".
        TrimString = LTrim(RTrim(TestString))
        ' Using the Trim function alone achieves the same result.
        ' Returns "<-Trim->".
        TrimString = Trim(TestString)