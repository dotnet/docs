        Dim appleLetters As New List(Of Char)(New Char() _
                                              {"a"c, "p"c, "p"c, "l"c, "e"c})

        ' Reverse the order of the characters in the collection.
        Dim reversed As IQueryable(Of Char) = _
           appleLetters.AsQueryable().Reverse()

        Dim output As New System.Text.StringBuilder
        For Each chr As Char In reversed
            output.Append(chr & " ")
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' e l p p a 
