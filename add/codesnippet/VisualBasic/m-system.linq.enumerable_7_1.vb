            ' Create a List of Char values.
            Dim appleLetters As New List(Of Char)(New Char() _
                                              {"a"c, "P"c, "P"c, "L"c, "E"c})

            ' Reverse the order of the elements in the list.
            ' (We have to call AsEnumerable() in order to
            ' use System.Linq.Enumerable's Reverse() method.
            Dim reversed() As Char =
            appleLetters.AsEnumerable().Reverse().ToArray()

            Dim output As New System.Text.StringBuilder
            For Each chr As Char In reversed
                output.Append(chr & " ")
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' E L P P a 
