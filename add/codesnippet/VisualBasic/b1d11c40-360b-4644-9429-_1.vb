        Sub AggregateEx1()
            Dim sentence As String =
            "the quick brown fox jumps over the lazy dog"
            ' Split the string into individual words.
            Dim words() As String = sentence.Split(" "c)
            ' Prepend each word to the beginning of the new sentence to reverse the word order.
            Dim reversed As String =
            words.Aggregate(Function(ByVal current, ByVal word) word & " " & current)

            ' Display the output.
            MsgBox(reversed)
        End Sub

        ' This code produces the following output:
        '
        ' dog lazy the over jumps fox brown quick the
