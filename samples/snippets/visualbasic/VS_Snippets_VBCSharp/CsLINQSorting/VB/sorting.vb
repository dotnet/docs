Module Sorting
    Sub Main(ByVal args As String())
        ThenByDescending()
    End Sub

    Sub OrderBy()
        ' <Snippet1>

        Dim words = {"the", "quick", "brown", "fox", "jumps"}

        Dim sortQuery = From word In words 
                        Order By word.Length 
                        Select word

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In sortQuery
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' the
        ' fox
        ' quick
        ' brown
        ' jumps

        ' </Snippet1>
    End Sub

    Sub OrderByDescending()
        ' <Snippet2>

        Dim words = {"the", "quick", "brown", "fox", "jumps"}

        Dim sortQuery = From word In words 
                        Order By word.Substring(0, 1) Descending 
                        Select word

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In sortQuery
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' the
        ' quick
        ' jumps
        ' fox
        ' brown

        ' </Snippet2>
    End Sub

    Sub ThenBy()
        ' <Snippet3>

        Dim words = {"the", "quick", "brown", "fox", "jumps"}

        Dim sortQuery = From word In words 
                        Order By word.Length, word.Substring(0, 1) 
                        Select word

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In sortQuery
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' fox
        ' the
        ' brown
        ' jumps
        ' quick

        ' </Snippet3>
    End Sub

    Sub ThenByDescending()
        ' <Snippet4>

        Dim words = {"the", "quick", "brown", "fox", "jumps"}

        Dim sortQuery = From word In words 
                        Order By word.Length, word.Substring(0, 1) Descending 
                        Select word

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In sortQuery
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' fox
        ' the
        ' quick
        ' jumps
        ' brown

        ' </Snippet4>
    End Sub
End Module
