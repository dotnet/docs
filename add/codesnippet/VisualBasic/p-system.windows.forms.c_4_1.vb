        Private Sub findButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim index As Integer
            index = comboBox1.FindString(textBox2.Text)
            comboBox1.SelectedIndex = index
        End Sub