    Private Function StringBuilderTest() As String
        Dim builder As New System.Text.StringBuilder
        For i As Integer = 1 To 1000
            builder.Append("Step " & i & vbCrLf)
        Next
        Return builder.ToString
    End Function