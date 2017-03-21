        ' Check if the 'ReadOnly' property is changed.
        Private Sub myDataGrid_ReadOnlyChanged(ByVal sender As Object, ByVal e As EventArgs) Handles myDataGrid.ReadOnlyChanged
            Dim strMessage As String = "false"
            If myDataGrid.ReadOnly = True Then
                strMessage = "true"
            End If
            MessageBox.Show("Read only changed to " + strMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'myDataGrid_ReadOnlyChanged

        ' Toggle the 'ReadOnly' property.
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            If myDataGrid.ReadOnly = True Then
                myDataGrid.ReadOnly = False
            Else
                myDataGrid.ReadOnly = True
            End If
        End Sub 'button2_Click