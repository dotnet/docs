    Private Sub ListBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ListBox1.SelectedIndex <> -1 Then
            textBox1.Text = ListBox1.SelectedValue.ToString()
            ' If we also wanted to get the displayed text we could use
            ' the SelectedItem item property:
            ' Dim s = CType(ListBox1.SelectedItem, USState).LongName
        End If
    End Sub 'ListBox1_SelectedValueChanged
End Class 'ListBoxSample3