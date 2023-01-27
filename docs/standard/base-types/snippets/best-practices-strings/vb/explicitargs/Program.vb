Module Program
    Sub Main()
        CompareWithDefault()
        CompareExplicit()
    End Sub

    Sub CompareWithDefault()
        '<default>
        Dim url As New Uri("https://learn.microsoft.com/")

        ' Incorrect
        If String.Equals(url.Scheme, "https") Then
            ' ...Code to handle HTTPS protocol.
        End If
        '</default>
    End Sub

    Sub CompareExplicit()
        '<explicit>
        Dim url As New Uri("https://learn.microsoft.com/")

        ' Incorrect
        If String.Equals(url.Scheme, "https", StringComparison.OrdinalIgnoreCase) Then
            ' ...Code to handle HTTPS protocol.
        End If
        '</explicit>
    End Sub
End Module
