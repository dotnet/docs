  Sub ContactsListView_ItemUpdating(ByVal sender As Object, ByVal e As ListViewUpdateEventArgs)
    
    ' Cancel the update operation if any of the fields is empty
    ' or null.
    For Each de As DictionaryEntry In e.NewValues
      ' Check if the value is null or empty
      If de.Value Is Nothing OrElse de.Value.ToString().Trim().Length = 0 Then
        Message.Text = "Cannot set a field to an empty value."
        e.Cancel = True
      End If
    Next
    
    ' Convert the e-mail address to lowercase.
    Dim emailValue As String = e.NewValues("EmailAddress").ToString()    
    e.NewValues("EmailAddress") = emailValue.ToLower()
    
  End Sub