   Private Sub SetHeaderText(ByVal sender As Object, ByVal e As EventArgs)
      ' Set the HeaderText property.
      myDataGridColumnStyle.HeaderText = "Emp ID"
      myDataGrid.Invalidate()
   End Sub 'SetHeaderText

   Private Sub ResetHeaderText(ByVal sender As Object, ByVal e As EventArgs)
      ' Reset the HeaderText property to its default value.
      myDataGridColumnStyle.ResetHeaderText()
      myDataGrid.Invalidate()
   End Sub 'ResetHeaderText