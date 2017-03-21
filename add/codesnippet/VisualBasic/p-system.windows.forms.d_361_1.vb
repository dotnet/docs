        ' Check if the 'FlatMode' property is changed.
        Private Sub myDataGrid_FlatModeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles myDataGrid.FlatModeChanged
            Dim strMessage As String = "false"
            If myDataGrid.FlatMode = True Then
                strMessage = "true"
            End If
            MessageBox.Show("Flat mode changed to " + strMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'myDataGrid_FlatModeChanged


        ' Toggle the 'FlatMode'.
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            If myDataGrid.FlatMode = True Then
                myDataGrid.FlatMode = False
            Else
                myDataGrid.FlatMode = True
            End If
        End Sub 'button1_Click