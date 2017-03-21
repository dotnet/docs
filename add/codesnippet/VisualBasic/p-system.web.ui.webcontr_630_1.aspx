  Sub ContactsListView_ItemInserting(ByVal sender As Object, _
                                     ByVal e As ListViewInsertEventArgs)
  
    ' Iterate through the values to verify if they are not empty.
    For Each de As DictionaryEntry In e.Values
      If de.Value Is Nothing Then
        Message.Text = "Cannot insert an empty value."
        e.Cancel = True
      End If
    Next
  End Sub