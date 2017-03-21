    Private Sub comboBox1_SelectionChangeCommitted(ByVal sender _
    As Object, ByVal e As EventArgs) _
    Handles comboBox1.SelectionChangeCommitted

        Dim senderComboBox As ComboBox = CType(sender, ComboBox)

        ' Change the length of the text box depending on what the user has 
        ' selected and committed using the SelectionLength property.
        If (senderComboBox.SelectionLength > 0) Then
            textbox1.Width = _
                senderComboBox.SelectedItem.ToString().Length() * _
                CType(Me.textbox1.Font.SizeInPoints, Integer)
            textbox1.Text = senderComboBox.SelectedItem.ToString()
        End If
    End Sub