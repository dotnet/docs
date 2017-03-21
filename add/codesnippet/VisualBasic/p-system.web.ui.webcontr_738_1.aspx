  Protected Sub ContactsListView_ItemCanceling(ByVal sender As Object, _
                                               ByVal e As ListViewCancelEventArgs)
    'Check the operation that raised the event
    If (e.CancelMode = ListViewCancelMode.CancelingEdit) Then
      ' The update operation was canceled. Display the 
      ' primary key of the item.
      Message.Text = "Update for the ContactID " & _
        ContactsListView.DataKeys(e.ItemIndex).Value.ToString() & " canceled."
    Else
      Message.Text = "Insert operation canceled."
    End If

  End Sub