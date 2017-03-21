Private Sub CreateDataGridGridTableStyle()
   Dim myCurrencyManager As CurrencyManager
   Dim myGridTableStyle As DataGridTableStyle
   ' Get the CurrencyManager for a DataTable named "Customers"
   ' found in a DataSet named "myDataSet". 
   myCurrencyManager = CType _
   (Me.BindingContext(myDataSet, "Customers"), CurrencyManager)
   myGridTableStyle = New DataGridTableStyle(myCurrencyManager)
   ' Add the table style to the collection of a DataGrid.
   myDataGrid.TableStyles.Add(myGridTableStyle)
End Sub 'CreateDataGridGridTableStyle