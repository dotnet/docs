  Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Check if an item is selected to delete it.
    If ContactsListView.SelectedIndex >= 0 Then
      ContactsListView.DeleteItem(ContactsListView.SelectedIndex)
    Else
      Message.Text = "No contact was selected."
    End If
    
  End Sub