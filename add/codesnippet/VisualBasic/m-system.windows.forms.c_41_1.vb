    ' Remove the first control in the collection.
    Private Sub RemoveAtButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles RemoveAtButton.Click
        If (Panel1.Controls.Count > 0) Then
            Panel1.Controls.RemoveAt(0)
        End If
    End Sub