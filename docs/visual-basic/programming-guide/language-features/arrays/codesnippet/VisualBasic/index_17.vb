    Public Sub Process()
        Dim numbers As Integer() = GetNumbers()
        ShowNumbers(numbers)
    End Sub

    Private Function GetNumbers() As Integer()
        Dim numbers As Integer() = {10, 20, 30}
        Return numbers
    End Function

    Private Sub ShowNumbers(numbers As Integer())
        For index = 0 To numbers.GetUpperBound(0)
            Debug.WriteLine(numbers(index) & " ")
        Next
    End Sub

    ' Output:
    '   10
    '   20
    '   30