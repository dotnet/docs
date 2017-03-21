   Public Sub AttachSelectionBackColorChanged()
      ' Handle the 'SelectionBackColorChanged' event.
      AddHandler myGridTableStyle.SelectionBackColorChanged, AddressOf MyDataGrid_SelectedBackColorChanged
   End Sub 'AttachSelectionBackColorChanged
   
   
    Private Sub MyDataGrid_SelectedBackColorChanged(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("SelectionBackColorChanged event was raised, Color changed to " & myGridTableStyle.SelectionBackColor.ToString())
    End Sub 'MyDataGrid_SelectedBackColorChanged
   