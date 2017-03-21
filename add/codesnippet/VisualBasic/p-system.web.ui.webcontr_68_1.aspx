  Sub ContactsListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    If ContactsListView.SelectedIndex >= 0 Then
      ViewState("SelectedKey") = ContactsListView.SelectedValue
    Else
      ViewState("SelectedKey") = Nothing
    End If
  End Sub

  Sub ContactsListView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    For i As Integer = 0 To ContactsListView.Items.Count - 1
      ' Ignore values that cannot be cast as integer.
      Try
        If Convert.ToInt32(ContactsListView.DataKeys(i).Value) = Convert.ToInt32(ViewState("SelectedKey")) Then _
          ContactsListView.SelectedIndex = i
      Catch
      End Try
    Next
  End Sub