    Structure Person
        <VBFixedString(30)> Dim Name As String
        Dim ID As Integer
    End Structure
    Public Sub ExampleMethod()
        ' Count 30 for the string, plus 4 for the integer.
        FileOpen(1, "TESTFILE", OpenMode.Random, , , 34)
        ' Close before reopening in another mode.
        FileClose(1)
    End Sub