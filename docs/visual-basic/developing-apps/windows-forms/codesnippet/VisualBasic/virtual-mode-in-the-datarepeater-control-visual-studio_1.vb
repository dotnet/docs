    Private Sub DataRepeater1_ItemValueNeeded(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventArgs
      ) Handles DataRepeater1.ItemValueNeeded
        If e.ItemIndex < Employees.Count Then
            Select Case e.Control.Name
                Case "txtFirstName"
                    e.Value = Employees.Item(e.ItemIndex + 1).firstName
                Case "txtLastName"
                    e.Value = Employees.Item(e.ItemIndex + 1).lastName
            End Select
        End If
    End Sub