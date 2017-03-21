            ' Create a list of strings.
            Dim fruits As New List(Of String)(New String() _
                                {"apple", "passionfruit", "banana", "mango",
                                 "orange", "blueberry", "grape", "strawberry"})

            ' Restrict the results to those strings whose 
            ' length is less than six.
            Dim query As IEnumerable(Of String) =
            fruits.Where(Function(fruit) fruit.Length < 6)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' mango
            ' grape
