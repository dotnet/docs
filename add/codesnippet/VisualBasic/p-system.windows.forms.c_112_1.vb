        Private Sub showSelectedButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim selectedIndex As Integer
            selectedIndex = comboBox1.SelectedIndex
            Dim selectedItem As Object
            selectedItem = comboBox1.SelectedItem

            MessageBox.Show("Selected Item Text: " & selectedItem.ToString() & Microsoft.VisualBasic.Constants.vbCrLf & _
                                "Index: " & selectedIndex.ToString())
        End Sub