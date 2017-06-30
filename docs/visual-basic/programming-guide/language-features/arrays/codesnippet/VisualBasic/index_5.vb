        Dim numbers(4) As Integer
        For i = 0 To 4
            numbers(i) = i ^ 2
        Next
        ' numbers contains 0, 1, 4, 9, 16
        ReDim Preserve numbers(5)
        ' numbers contains 0, 1, 4, 9, 16, 0
        ReDim numbers(4)
        ' numbers contains 0, 0, 0, 0, 0
