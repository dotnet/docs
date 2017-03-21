  Sub ContactsListView_ItemInserted(ByVal sender As Object, ByVal e As ListViewInsertedEventArgs)

    If e.Exception IsNot Nothing Then

      If e.AffectedRows = 0 Then
        e.KeepInInsertMode = True
        Message.Text = "An exception occurred inserting the new Contact. " & _
          "Please verify your values and try again."
      Else
        Message.Text = "An exception occurred inserting the new Contact. " & _
          "Please verify the values in the newly inserted item."
      End If

      e.ExceptionHandled = True
    End If
  End Sub