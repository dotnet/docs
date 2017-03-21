            ' Create two arrays of integer values.
            Dim ints1() As Integer = {5, 3, 9, 7, 5, 9, 3, 7}
            Dim ints2() As Integer = {8, 3, 6, 4, 4, 9, 1, 0}

            ' Get the set union of the two arrays.
            Dim union As IEnumerable(Of Integer) = ints1.Union(ints2)

            ' Display the resulting set's values.
            Dim output As New System.Text.StringBuilder
            For Each num As Integer In union
                output.AppendLine(num & " ")
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 5 
            ' 3 
            ' 9 
            ' 7 
            ' 8 
            ' 6 
            ' 4 
            ' 1 
            ' 0 
