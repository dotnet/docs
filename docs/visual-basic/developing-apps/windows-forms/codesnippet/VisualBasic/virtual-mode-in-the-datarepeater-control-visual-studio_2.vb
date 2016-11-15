    Private Sub DataRepeater1_ItemValuePushed(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventArgs
      ) Handles DataRepeater1.ItemValuePushed

        Dim emp As Employee = Employees.Item(e.ItemIndex)
        Select Case e.Control.Name
            Case "txtFirstName"
                emp.firstName = e.Control.Text
            Case "txtLastName"
                emp.lastName = e.Control.Text
            Case Else
                MsgBox("Error during ItemValuePushed unexpected control: " & 
                    e.Control.Name)
        End Select
    End Sub