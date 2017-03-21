        Dim ints1() As Integer = {5, 3, 9, 7, 5, 9, 3, 7}
        Dim ints2() As Integer = {8, 3, 6, 4, 4, 9, 1, 0}

        ' Get the set union of the items in the two arrays.
        Dim union = ints1.AsQueryable().Union(ints2)

        Dim output As New System.Text.StringBuilder
        For Each num As Integer In union
            output.Append(String.Format("{0} ", num))
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 5 3 9 7 8 6 4 1 0
