    Public Sub ListEvenNumbers()
        For Each number As Integer In EvenSequence(5, 18)
            Debug.Write(number & " ")
        Next
        Debug.WriteLine("")
        ' Output: 6 8 10 12 14 16 18
    End Sub

    Private Iterator Function EvenSequence(
    ByVal firstNumber As Integer, ByVal lastNumber As Integer) _
    As System.Collections.Generic.IEnumerable(Of Integer)

        ' Yield even numbers in the range.
        For number = firstNumber To lastNumber
            If number Mod 2 = 0 Then
                Yield number
            End If
        Next
    End Function