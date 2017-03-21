   Private Sub button3_Click(sender As Object, e As EventArgs)
      Try
         Dim myBindingManager1 As BindingManagerBase = BindingContext(myDataSet, "Customers")
         myBindingManager1.SuspendBinding()
      Catch ex As Exception
         MessageBox.Show(ex.Source.ToString())
         MessageBox.Show(ex.Message.ToString())
      End Try
   End Sub 'button3_Click
   