        Dim numberSeq() As Integer =
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}

        For Each number As Integer In numberSeq
            ' If number is between 5 and 7, continue
            ' with the next iteration.
            If number >= 5 And number <= 8 Then
                Continue For
            End If

            ' Display the number.
            Debug.Write(number.ToString & " ")

            ' If number is 10, exit the loop.
            If number = 10 Then
                Exit For
            End If
        Next
        Debug.WriteLine("")
        ' Output: 1 2 3 4 9 10