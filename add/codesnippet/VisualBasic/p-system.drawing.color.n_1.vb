    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Button2.Width = 100
        Button2.Text = "Color: " + Button2.BackColor.Name
    End Sub