Private Sub AddCustomDataTableStyle()
   Dim ts1 As New DataGridTableStyle()
   ts1.MappingName = "Customers"
   ' Set other properties.
   ts1.AlternatingBackColor = Color.LightGray
   ' Add a GridColumnStyle and set its MappingName 
   ' to the name of a DataColumn in the DataTable. 
   ' Set the HeaderText and Width properties. 
     
   Dim boolCol As New DataGridBoolColumn()
   boolCol.MappingName = "Current"
   boolCol.HeaderText = "IsCurrent Customer"
   boolCol.Width = 150
   ts1.GridColumnStyles.Add(boolCol)
     
   ' Add a second column style.
   Dim TextCol As New DataGridTextBoxColumn()
   TextCol.MappingName = "custName"
   TextCol.HeaderText = "Customer Name"
   TextCol.Width = 250
   ts1.GridColumnStyles.Add(TextCol)
     
   ' Create the second table style with columns.
   Dim ts2 As New DataGridTableStyle()
   ts2.MappingName = "Orders"
     
   ' Set other properties.
   ts2.AlternatingBackColor = Color.LightBlue
     
   ' Create new ColumnStyle objects.
   Dim cOrderDate As New DataGridTextBoxColumn()
   cOrderDate.MappingName = "OrderDate"
   cOrderDate.HeaderText = "Order Date"
   cOrderDate.Width = 100
   ts2.GridColumnStyles.Add(cOrderDate)

   ' Use a PropertyDescriptor to create a formatted
   ' column. First get the PropertyDescriptorCollection
   ' for the data source and data member. 
   Dim pcol As System.ComponentModel.PropertyDescriptorCollection = _
   Me.BindingContext(myDataSet, "Customers.custToOrders"). _
   GetItemProperties()

   ' Create a formatted column using a PropertyDescriptor.
   ' The formatting character "c" specifies a currency format. */     
     
   Dim csOrderAmount As _
   New DataGridTextBoxColumn(pcol("OrderAmount"), "c", True)
   csOrderAmount.MappingName = "OrderAmount"
   csOrderAmount.HeaderText = "Total"
   csOrderAmount.Width = 100
   ts2.GridColumnStyles.Add(csOrderAmount)
     
   ' Add the DataGridTableStyle instances to 
   ' the GridTableStylesCollection. 
   myDataGrid.TableStyles.Add(ts1)
   myDataGrid.TableStyles.Add(ts2)
End Sub 'AddCustomDataTableStyle