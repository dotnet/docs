        Dim index As Integer = 0
        Do While index <= 100
            If index > 10 Then
                Exit Do
            End If

            Debug.Write(index.ToString & " ")
            index += 1
        Loop

        Debug.WriteLine("")
        ' Output: 0 1 2 3 4 5 6 7 8 9 10 