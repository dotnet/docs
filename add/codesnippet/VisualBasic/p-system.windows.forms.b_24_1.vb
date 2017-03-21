    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        If binding1.SupportsSearching <> True Then
            MessageBox.Show("Cannot search the list.")
        Else
            Dim foundIndex As Integer = binding1.Find("Name", textBox1.Text)
            If foundIndex > -1 Then
                listBox1.SelectedIndex = foundIndex
            Else
                MessageBox.Show("Font was not found.")
            End If
        End If

    End Sub
End Class