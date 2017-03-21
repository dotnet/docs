    ' Remove the RadioButton control if it exists.
    Private Sub RemoveButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles RemoveButton.Click
        If Panel1.Controls.Contains(RemoveButton) Then
            Panel1.Controls.Remove(RemoveButton)
        End If
    End Sub