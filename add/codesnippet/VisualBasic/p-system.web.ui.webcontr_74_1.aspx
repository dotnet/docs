    Sub ContactsListView_ItemUpdated(sender As Object, e As ListViewUpdatedEventArgs)
        If e.Exception IsNot Nothing Then
            If e.AffectedRows = 0 Then
                e.KeepInEditMode = True
                Message.Text = "An exception occurred updating the contact. " & _
                                    "Please verify your values and try again."
            Else
                Message.Text = "An exception occurred updating the contact. " & _
                                    "Please verify the values in the recently updated item."
            End If

            e.ExceptionHandled = True
        End If
    End Sub