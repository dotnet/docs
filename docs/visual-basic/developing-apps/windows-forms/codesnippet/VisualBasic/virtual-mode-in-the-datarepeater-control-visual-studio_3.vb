    Private Sub Child_KeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.KeyEventArgs
      ) Handles txtFirstName.KeyDown, txtLastName.KeyDown

        If e.KeyCode = Keys.Escape Then
            Datarepeater1.CancelEdit()
        End If
    End Sub