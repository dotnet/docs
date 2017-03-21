        Dim sentence As String = "the quick brown fox jumps over the lazy dog"

        ' Split the string into individual words.
        Dim words() As String = sentence.Split(" "c)

        ' Use Aggregate() to prepend each word to the beginning of the 
        ' new sentence to reverse the word order.
        Dim reversed As String = _
            words.AsQueryable().Aggregate( _
                Function(ByVal workingSentence, ByVal nextWord) nextWord & " " & workingSentence _
            )

        MsgBox(reversed)

        ' This code produces the following output:
        '
        ' dog lazy the over jumps fox brown quick the
