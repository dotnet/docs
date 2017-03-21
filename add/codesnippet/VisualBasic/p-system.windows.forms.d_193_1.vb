      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle1 = New DataGridTableStyle()
         myDataGridTableStyle2 = New DataGridTableStyle()

         MessageBox.Show("LinkColor Before : " & myDataGridTableStyle1.LinkColor.ToString)
         MessageBox.Show("HeaderFont Before : " & myDataGridTableStyle1.HeaderFont.ToString)

         AddHandler myDataGridTableStyle1.LinkColorChanged, AddressOf LinkColorChanged_Handler
         AddHandler myDataGridTableStyle1.HeaderFontChanged, AddressOf HeaderFontChanged_Handler
         myDataGridTableStyle1.MappingName = "Customers"

         ' Set other properties.
         myDataGridTableStyle1.AlternatingBackColor = Color.LightGray
         myDataGridTableStyle1.LinkColor = Color.Red
         myDataGridTableStyle1.HeaderFont = New System.Drawing.Font _
                  ("Verdana", 8.25F, System.Drawing.FontStyle.Bold, _
                   System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))

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

         ' Create new ColumnStyle objects
         Dim cOrderDate = New DataGridTextBoxColumn()
         cOrderDate.MappingName = "OrderDate"
         cOrderDate.HeaderText = "Order Date"
         cOrderDate.Width = 100

         ' PropertyDescriptor to create a formatted column.
         Dim myPropertyDescriptorCollection As PropertyDescriptorCollection = _
                  Me.BindingContext(myDataSet, "Customers.custToOrders").GetItemProperties()

         Dim csOrderAmount = New DataGridTextBoxColumn(myPropertyDescriptorCollection _
                                 ("OrderAmount"), "c", True)
         csOrderAmount.MappingName = "OrderAmount"
         csOrderAmount.HeaderText = "Total"
         csOrderAmount.Width = 100

         ' Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1)
      End Sub 'AddCustomDataTableStyle

      Private Sub LinkColorChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("LinkColor changed to 'RED'", "DataGridTableStyle")
      End Sub 'LinkColorChanged_Handler


      Private Sub HeaderFontChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("HeaderFont changed to 'VERDANA'", "DataGridTableStyle")
      End Sub 'HeaderFontChanged_Handler