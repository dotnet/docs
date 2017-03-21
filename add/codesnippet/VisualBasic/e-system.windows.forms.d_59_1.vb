   Private Sub SetUp()
      ' Create a DataSet with a table.
      MakeDataSet()
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Orders")
      myTableStyle = New DataGridTableStyle()
      ' Map 'DataGridTableStyle' instance to the DataTable.
      myTableStyle.MappingName = "Orders"
      ' Add EventHandler function for 'PreferredRowHeightChanged' Event.
      AddHandler myTableStyle.PreferredRowHeightChanged, AddressOf RowHeight_Changed
   End Sub 'SetUp

   ' Called when the PreferredRowHeight property of myTableStyle is modified
    Private Sub RowHeight_Changed(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("PreferredRowHeight property is changed")
    End Sub 'RowHeight_Changed
   