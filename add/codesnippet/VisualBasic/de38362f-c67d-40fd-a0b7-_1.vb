    ' Create a TextBox to add to the Panel.
    Dim TextBox1 As TextBox = New TextBox()

    ' Add controls to the Panel using the Add method.
    Private Sub AddButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles AddButton.Click
        Panel1.Controls.Add(TextBox1)
    End Sub