            ' Create an array of double values.
            Dim doubles() As Double = {1.5E+104, 9.0E+103, -2.0E+103}

            ' Determine the smallest number in the array.
            Dim min As Double = doubles.Min()

            ' Display the result.
            MsgBox("The smallest number is " & min)

            ' This code produces the following output:
            '
            ' The smallest number is -2E+103
