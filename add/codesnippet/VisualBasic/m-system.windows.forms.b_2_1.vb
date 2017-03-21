      Private Sub button1_Click(sender As Object, e As EventArgs)
         Try
            ' Get the 'BindingManagerBase' object.
            Dim myBindingManagerBase As BindingManagerBase = BindingContext(myDataTable)
            ' Remove the selected row from the grid.
            myBindingManagerBase.RemoveAt(myBindingManagerBase.Position)
         Catch ex As Exception
            MessageBox.Show(ex.Source)
            MessageBox.Show(ex.Message)
         End Try
      End Sub 'button1_Click
      