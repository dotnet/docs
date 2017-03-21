    Sub ValidateBtn_Click(sender As Object, e As EventArgs)
        Page.Validate()
        If (Page.IsValid) Then
            lblOutput.Text = "Page is Valid!"
        Else
            lblOutput.Text = "Some required fields are empty."
        End If
    End Sub