            ' Create a list of Single values.
            Dim numbers As New List(Of Single)(New Single() _
                                           {43.68F, 1.25F, 583.7F, 6.5F})

            ' Get the sum of values in the list.
            Dim sum As Single = numbers.Sum()

            ' Display the output.
            MsgBox("The sum of the numbers is " & sum)

            ' This code produces the following output:
            '
            ' The sum of the numbers is 635.13
