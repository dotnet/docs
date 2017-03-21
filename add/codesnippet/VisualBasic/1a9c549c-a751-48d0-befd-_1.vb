   ' Create a DataSet with a table and populate it.
   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      Dim tPer As New DataTable("Person")
      Dim cPerName As New DataColumn("PersonName")

      tPer.Columns.Add(cPerName)
      myDataSet.Tables.Add(tPer)

      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 1 To 5
         newRow1 = tPer.NewRow()
         tPer.Rows.Add(newRow1)
      Next i

      tPer.Rows(0)("PersonName") = "Robert"
      tPer.Rows(1)("PersonName") = "Michael"
      tPer.Rows(2)("PersonName") = "John"
      tPer.Rows(3)("PersonName") = "Walter"
      tPer.Rows(4)("PersonName") = "Simon"

      ' Bind the 'DataSet' to the 'DataGrid'.
      myDataGrid.SetDataBinding(myDataSet, "Person")
      myDataGridTextBox.DataBindings.Add("Text", myDataSet, "Person.PersonName")
      ' Set the DataGrid to the DataGridTextBox.
      myDataGridTextBox.SetDataGrid(myDataGrid)
   End Sub 'MakeDataSet