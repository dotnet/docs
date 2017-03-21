            ' Create an array of Nullable Double values.
            Dim doubles() As Nullable(Of Double) =
            {Nothing, 1.5E+104, 9.0E+103, -2.0E+103}

            ' Determine the maximum value in the array.
            Dim max As Nullable(Of Double) = doubles.Max()

            ' Display the result.
            MsgBox("The largest number is " & max)

            ' This code produces the following output:
            '
            ' The largest number is 1.5E+104
