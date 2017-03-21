            ' Repeat the same string to create a sequence.
            Dim sentences As IEnumerable(Of String) =
            Enumerable.Repeat("I like programming.", 15)

            Dim output As New System.Text.StringBuilder
            For Each sentence As String In sentences
                output.AppendLine(sentence)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
