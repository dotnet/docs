Private Sub CreateDataSet
   myDataSet = new DataSet("myDataSet")
   ' Populates the DataSet with tables, relations, and
   ' constraints.
End Sub

Private Sub BindTextBoxToDataSet 
   ' Binds a TextBox control to a column in the DataSet.
   textBox1.DataBindings.Add _
   ("Text", myDataSet, "Suppliers.CompanyName")
End Sub