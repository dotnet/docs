      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle1 = New DataGridTableStyle()

         ' EventHandlers
         AddHandler myDataGridTableStyle1.GridLineColorChanged, AddressOf GridLineColorChanged_Handler
         myDataGridTableStyle1.MappingName = "Customers"

         ' Set other properties.
         myDataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gold
         myDataGridTableStyle1.BackColor = System.Drawing.Color.White
         myDataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.Solid
         myDataGridTableStyle1.GridLineColor = Color.Red

         ' Set the HeaderText and Width properties.
         Dim myBoolCol = New DataGridBoolColumn()
         myBoolCol.MappingName = "Current"
         myBoolCol.HeaderText = "IsCurrent Customer"
         myBoolCol.Width = 150
         myDataGridTableStyle1.GridColumnStyles.Add(myBoolCol)

         ' Add a second column style.
         Dim myTextCol = New DataGridTextBoxColumn()
         myTextCol.MappingName = "custName"
         myTextCol.HeaderText = "Customer Name"
         myTextCol.Width = 250
         myDataGridTableStyle1.GridColumnStyles.Add(myTextCol)

         ' Create new ColumnStyle objects
         Dim cOrderDate = New DataGridTextBoxColumn()
         cOrderDate.MappingName = "OrderDate"
         cOrderDate.HeaderText = "Order Date"
         cOrderDate.Width = 100

         ' Use a PropertyDescriptor to create a formatted column.
         Dim myPropertyDescriptorCollection As PropertyDescriptorCollection = _
                        BindingContext(myDataSet, "Customers.custToOrders").GetItemProperties()

         ' Create a formatted column using a PropertyDescriptor.
         Dim csOrderAmount = New DataGridTextBoxColumn(myPropertyDescriptorCollection( _
                                                      "OrderAmount"), "c", True)
         csOrderAmount.MappingName = "OrderAmount"
         csOrderAmount.HeaderText = "Total"
         csOrderAmount.Width = 100

         ' Add the DataGridTableStyle instances to the GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1)
      End Sub 'AddCustomDataTableStyle

      Private Sub GridLineColorChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("GridLineColor Changed", "DataGridTableStyle")
      End Sub 'GridLineColorChanged_Handler