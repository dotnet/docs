Private Sub SetBoolColumnValues()
   Dim myGridColumn As DataGridBoolColumn 
   ' Get the DataGridBoolColumn you are setting.
   myGridColumn = CType(myDataGrid.TableStyles _
   ("Customers").GridColumnStyles("Current"), DataGridBoolColumn)
   ' Set TrueValue, FalseValue, and NullValue.
   myGridColumn.TrueValue = true
   myGridColumn.FalseValue = false
   myGridColumn.NullValue = Convert.DBNull
End Sub
