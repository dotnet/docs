            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Determine the average length of the strings in the array.
            Dim avg As Double = fruits.Average(Function(s) s.Length)

            ' Display the output.
            MsgBox("The average string length is " & avg)

            ' This code produces the following output:
            '
            ' The average string length is 6.5
