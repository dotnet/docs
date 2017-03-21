        Private Sub addGrandButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            comboBox1.BeginUpdate()
            Dim I As Integer
            For I = 0 To 1000
                comboBox1.Items.Add("New Item " + i.ToString())
            Next
            comboBox1.EndUpdate()
        End Sub