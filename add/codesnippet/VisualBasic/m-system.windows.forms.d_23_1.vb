        Private Sub BtnSetForeColor_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Set the foreground color of table.
            myDataGridTableStyle.ForeColor = Color.Blue
            myDataGrid.TableStyles.Add(myDataGridTableStyle)
        End Sub 'BtnSetForeColor_Click
      
        Private Sub BtnResetForeColor_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Reset the foreground color of table to its default value.
            myDataGridTableStyle.ResetForeColor()
        End Sub 'BtnResetForeColor_Click