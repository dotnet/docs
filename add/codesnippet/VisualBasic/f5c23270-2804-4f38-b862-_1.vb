        Dim numbers1() As Double = {2.0, 2.1, 2.2, 2.3, 2.4, 2.5}
        Dim numbers2() As Double = {2.2}

        ' Get the numbers from the first array that
        ' are NOT in the second array.
        Dim onlyInFirstSet As IEnumerable(Of Double) = _
            numbers1.AsQueryable().Except(numbers2)

        Dim output As New System.Text.StringBuilder
        For Each number As Double In onlyInFirstSet
            output.AppendLine(number)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' 2
        ' 2.1
        ' 2.3
        ' 2.4
        ' 2.5
