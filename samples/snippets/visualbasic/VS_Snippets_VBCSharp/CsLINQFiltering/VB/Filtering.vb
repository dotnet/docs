Module Filtering
    Sub Main(ByVal args As String())
        Where()
    End Sub

    Sub Where()
        ' <Snippet1>

        Dim words() As String = {"the", "quick", "brown", "fox", "jumps"}

        Dim query = From word In words 
                    Where word.Length = 3 
                    Select word

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In query
            sb.AppendLine(str)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' the
        ' fox

        ' </Snippet1>
    End Sub
End Module
