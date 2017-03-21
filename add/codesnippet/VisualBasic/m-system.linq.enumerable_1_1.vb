            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "passionfruit", "banana", "mango",
             "orange", "blueberry", "grape", "strawberry"}

            ' Project the length of each string and 
            ' put the length values into a List object.
            Dim lengths As List(Of Integer) =
            fruits _
            .Select(Function(fruit) fruit.Length) _
            .ToList()

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each length As Integer In lengths
                output.AppendLine(length)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 5
            ' 12
            ' 6
            ' 5
            ' 6
            ' 9
            ' 5
            ' 10
