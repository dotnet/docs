   Private Sub button4_Click(sender As Object, e As EventArgs)
      Try
         Dim myBindingManager2 As BindingManagerBase = BindingContext(myDataSet, "Customers")
         myBindingManager2.ResumeBinding()
      Catch ex As Exception
         MessageBox.Show(ex.Source.ToString())
         MessageBox.Show(ex.Message.ToString())
      End Try
   End Sub 'button4_Click