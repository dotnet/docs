            ' Create an array of strings.
            Dim numbers() As String = {"10007", "37", "299846234235"}

            ' Determine the average number after converting each
            ' string to an Int64 value.
            Dim avg As Double =
            numbers.Average(Function(number) Convert.ToInt64(number))

            ' Display the output.
            MsgBox("The average is " & avg)

            ' This code produces the following output:
            '
            ' The average is 99948748093
