
        Dim words = {"an", "apple", "a", "day", "keeps", "the", "doctor", "away"}

        Dim query = From word In words 
                    Skip While word.Substring(0, 1) = "a"

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In query
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' day
        ' keeps
        ' the
        ' doctor
        ' away
