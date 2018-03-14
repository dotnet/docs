        Dim row, col As Integer
        Dim lastrow As Integer = 6
        Dim lastcol As Integer = 10
        Dim a(,) As Double = New Double(lastrow, lastcol) {}
        Dim b(7) As Double
        row = -1
        While row < lastrow
            row += 1
            col = -1
            While col < lastcol
                col += 1
                a(row, col) = 0
                For i As Integer = 0 To b.GetUpperBound(0)
                    If b(i) = col Then
                        Continue While
                    Else
                        a(row, col) += (row + b(i)) / (col - b(i))
                    End If
                Next i
            End While
        End While