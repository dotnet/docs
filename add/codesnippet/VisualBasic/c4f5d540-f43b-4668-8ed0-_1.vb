            ' Create two integer arrays.
            Dim id1() As Integer = {44, 26, 92, 30, 71, 38}
            Dim id2() As Integer = {39, 59, 83, 47, 26, 4, 30}

            ' Find the set intersection of the two arrays.
            Dim intersection As IEnumerable(Of Integer) = id1.Intersect(id2)

            Dim output As New System.Text.StringBuilder
            For Each id As Integer In intersection
                output.AppendLine(id)
            Next

            ' Display the output.
            MsgBox(output.ToString)

            ' This code produces the following output:
            '
            ' 26
            ' 30
