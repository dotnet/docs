    Public Function findValue(ByVal arr() As Double, 
        ByVal searchValue As Double) As Double
        Dim i As Integer = 0
        While i <= UBound(arr) AndAlso arr(i) <> searchValue
            ' If i is greater than UBound(arr), searchValue is not checked.
            i += 1
        End While
        If i > UBound(arr) Then i = -1
        Return i
    End Function