    Public Sub ListPrimes()
        ' The sb variable can be accessed only
        ' within the ListPrimes procedure.
        Dim sb As New System.Text.StringBuilder()

        ' The number variable can be accessed only
        ' within the For...Next block.  A different
        ' variable with the same name could be declared
        ' outside of the For...Next block.
        For number As Integer = 1 To 30
            If CheckIfPrime(number) = True Then
                sb.Append(number.ToString & " ")
            End If
        Next

        Debug.WriteLine(sb.ToString)
        ' Output: 2 3 5 7 11 13 17 19 23 29
    End Sub


    Private Function CheckIfPrime(ByVal number As Integer) As Boolean
        If number < 2 Then
            Return False
        Else
            ' The root and highCheck variables can be accessed
            ' only within the Else block.  Different variables
            ' with the same names could be declared outside of
            ' the Else block.
            Dim root As Double = Math.Sqrt(number)
            Dim highCheck As Integer = Convert.ToInt32(Math.Truncate(root))

            ' The div variable can be accessed only within
            ' the For...Next block.
            For div As Integer = 2 To highCheck
                If number Mod div = 0 Then
                    Return False
                End If
            Next

            Return True
        End If
    End Function