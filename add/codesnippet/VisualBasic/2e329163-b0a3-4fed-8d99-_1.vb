            ' Create a list of Long values.
            Dim longs As New List(Of Long)(New Long() _
                                       {4294967296L, 466855135L, 81125L})

            ' Get the maximum value in the list.
            Dim max As Long = longs.Max()

            ' Display the result.
            MsgBox("The largest number is " & max)

            ' This code produces the following output:
            '
            ' The largest number is 4294967296
