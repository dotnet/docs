Module Partitioning
    Sub Main(ByVal args As String())
        TakeWhile()
    End Sub

    Sub Skip()
        ' <Snippet1>

        Dim words = {"an", "apple", "a", "day", "keeps", "the", "doctor", "away"}

        Dim query = From word In words 
                    Skip 4

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In query
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' keeps
        ' the
        ' doctor
        ' away

        ' </Snippet1>

    End Sub

    Sub SkipWhile()
        ' <Snippet2>

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

        ' </Snippet2>

    End Sub

    Sub Take()
        ' <Snippet3>

        Dim words = {"an", "apple", "a", "day", "keeps", "the", "doctor", "away"}

        Dim query = From word In words 
                    Take 2

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In query
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' an
        ' apple

        ' </Snippet3>

    End Sub

    Sub TakeWhile()
        ' <Snippet4>

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

        ' </Snippet4>

    End Sub

End Module