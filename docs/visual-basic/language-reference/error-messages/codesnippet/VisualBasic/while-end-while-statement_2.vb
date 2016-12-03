        Dim index As Integer = 0
        While index < 100000
            index += 1

            ' If index is between 5 and 7, continue
            ' with the next iteration.
            If index >= 5 And index <= 8 Then
                Continue While
            End If

            ' Display the index.
            Debug.Write(index.ToString & " ")

            ' If index is 10, exit the loop.
            If index = 10 Then
                Exit While
            End If
        End While

        Debug.WriteLine("")
        ' Output: 1 2 3 4 9 10