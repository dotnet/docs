    Private Sub Text_Validating(
        ByVal sender As Object, 
        ByVal e As System.ComponentModel.CancelEventArgs
      ) Handles txtFirstName.Validating, txtLastName.Validating

        If txtFirstName.Text = "" Then
            MsgBox("Please enter a name.")
            e.Cancel = True
        End If
    End Sub