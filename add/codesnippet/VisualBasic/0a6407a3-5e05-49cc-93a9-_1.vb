            Dim grades() As Nullable(Of Integer) = {78, 92, Nothing, 99, 37, 81}
            Dim min As Nullable(Of Integer) = grades.Min()

            ' Display the output.
            MsgBox("The lowest grade is " & min)

            ' This code produces the following output:
            '
            ' The lowest grade is 37
