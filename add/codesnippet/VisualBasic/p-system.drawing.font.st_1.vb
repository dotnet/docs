     Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        If Not Button1.Font.Style = FontStyle.Bold Then
            Button1.Font = New Font(FontFamily.GenericSansSerif, _
                12.0F, FontStyle.Bold)
        End If
    End Sub