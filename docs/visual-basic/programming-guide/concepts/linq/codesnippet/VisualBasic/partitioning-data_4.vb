
        Dim words = {"an", "apple", "a", "day", "keeps", "the", "doctor", "away"}

        Dim query = From word In words 
                    Take While word.Length < 6

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In query
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' an
        ' apple
        ' a
        ' day
        ' keeps
        ' the
