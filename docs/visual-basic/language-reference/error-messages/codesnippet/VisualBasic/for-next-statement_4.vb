        For index As Integer = 1 To 100000
            ' If index is between 5 and 7, continue
            ' with the next iteration.
            If index >= 5 And index <= 8 Then
                Continue For
            End If

            ' Display the index.
            Debug.Write(index.ToString & " ")

            ' If index is 10, exit the loop.
            If index = 10 Then
                Exit For
            End If
        Next
        Debug.WriteLine("")
        ' Output: 1 2 3 4 9 10