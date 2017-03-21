    Private Sub AlignmentChanged_Click(ByVal sender As Object, ByVal e As EventArgs)
        myMessage = "Alignment has been Changed"
    End Sub 'AlignmentChanged_Click

   Private Sub AddCustomDataTableStyle()
      ' Create a 'DataGridTableStyle'.
      Dim myDataTableStyle As New DataGridTableStyle()
      myDataTableStyle.MappingName = "Customers"
      ' Create a 'DataGridColumnStyle'.
      myDataGridColumnStyle = New DataGridTextBoxColumn()
      myDataGridColumnStyle.MappingName = "CustName"
      myDataGridColumnStyle.HeaderText = "Customer Name"
      myDataGridColumnStyle.Width = 250
      AddHandler myDataGridColumnStyle.AlignmentChanged, AddressOf AlignmentChanged_Click
      ' Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
      myDataTableStyle.GridColumnStyles.Add(myDataGridColumnStyle)
      ' Add the 'DataGridTableStyle' to 'DataGrid'.
      myDataGrid.TableStyles.Add(myDataTableStyle)
   End Sub 'AddCustomDataTableStyle