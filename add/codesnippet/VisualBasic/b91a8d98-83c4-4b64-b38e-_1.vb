            ' Create a list of integers.
            Dim grades As New List(Of Integer)(New Integer() {78, 92, 100, 37, 81})

            ' Determine the average value in the list.
            Dim avg As Double = grades.Average()

            ' Display the output.
            MsgBox("The average grade is " & avg)

            ' This code produces the following output:
            '
            ' The average grade is 77.6
