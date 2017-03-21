      Private Sub AddContextMenuChangedHandler()
         AddHandler Me.myTextBox.ContextMenuChanged, AddressOf TextBox_ContextMenuChanged
      End Sub 'AddContextMenuChangedHandler

      Private Sub TextBox_ContextMenuChanged(sender As Object, e As EventArgs)
         MessageBox.Show("Shortcut menu of TextBox is changed.")
      End Sub 'TextBox_ContextMenuChanged
