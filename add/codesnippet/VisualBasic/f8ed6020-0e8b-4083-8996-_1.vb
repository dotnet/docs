            ' Create an array of nullable long values.
            Dim longs() As Nullable(Of Long) = {Nothing, 10007L, 37L, 399846234235L}

            ' Determine the average value in the array.
            Dim avg As Nullable(Of Double) = longs.Average()

            ' Display the output.
            MsgBox("The average is " & avg.ToString)

            ' This code produces the following output:
            '
            ' The average is 133282081426.333
