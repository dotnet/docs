      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle1 = New DataGridTableStyle()
         AddHandler myDataGridTableStyle1.MappingNameChanged, AddressOf MappingNameChanged_Handler
         AddHandler myDataGridTableStyle1.GridLineStyleChanged, AddressOf GridLineStyleChanged_Handler
         myDataGridTableStyle1.MappingName = "Customers"

         ' Set other properties.
         myDataGridTableStyle1.AlternatingBackColor = Color.LightGray
         myDataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None

         ' Add a GridColumnStyle and set its MappingName.
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

         ' Create new ColumnStyle objects.
         Dim cOrderDate = New DataGridTextBoxColumn()
         cOrderDate.MappingName = "OrderDate"
         cOrderDate.HeaderText = "Order Date"
         cOrderDate.Width = 100

         ' Use PropertyDescriptor to create a formatted column.
         Dim myPropertyDescriptorCollection As PropertyDescriptorCollection = _
                     Me.BindingContext(myDataSet, "Customers.custToOrders").GetItemProperties()
         Dim csOrderAmount = New DataGridTextBoxColumn _
                  (myPropertyDescriptorCollection("OrderAmount"), "c", True)
         csOrderAmount.MappingName = "OrderAmount"
         csOrderAmount.HeaderText = "Total"
         csOrderAmount.Width = 100

         ' Add the DataGridTableStyle object to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1)
      End Sub 'AddCustomDataTableStyle

      Private Sub MappingNameChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("MappingName Changed", "DataGridTableStyle")
      End Sub 'MappingNameChanged_Handler

      Private Sub GridLineStyleChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("GridLineStyle  Changed", "DataGridTableStyle")
      End Sub 'GridLineStyleChanged_Handler