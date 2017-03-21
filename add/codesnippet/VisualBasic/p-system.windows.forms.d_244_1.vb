      Private Sub DataGridTableStyle_Sample_Load(ByVal sender As Object, _
                                 ByVal e As EventArgs) Handles MyBase.Load
         myDataGridTableStyle1 = New DataGridTableStyle()
         myHeaderLabel.Text = "Header Status :" + myDataGridTableStyle1.ColumnHeadersVisible.ToString()
         If myDataGridTableStyle1.ColumnHeadersVisible = True Then
            btnheader.Text = "Remove Header"
         Else
            btnheader.Text = "Add Header"
         End If
         AddCustomDataTableStyle()
      End Sub 'DataGridTableStyle_Sample_Load

      Private Sub AddCustomDataTableStyle()
         AddHandler myDataGridTableStyle1.ColumnHeadersVisibleChanged, AddressOf ColumnHeadersVisibleChanged_Handler

         ' Set ColumnheaderVisible property.
         myDataGridTableStyle1.MappingName = "Customers"

         ' Add a GridColumnStyle and set its MappingName
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

         ' Create a formatted column using a PropertyDescriptor.
         Dim csOrderAmount = New DataGridTextBoxColumn(myPropertyDescriptorCollection("OrderAmount"), "c", True)
         csOrderAmount.MappingName = "OrderAmount"
         csOrderAmount.HeaderText = "Total"
         csOrderAmount.Width = 100

         ' Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1)
      End Sub 'AddCustomDataTableStyle

      Private Sub ColumnHeadersVisibleChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         myHeaderLabel.Text = "Header Status :" + myDataGridTableStyle1.ColumnHeadersVisible.ToString()
      End Sub 'ColumnHeadersVisibleChanged_Handler

      Private Sub btnheader_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnheader.Click
         If myDataGridTableStyle1.ColumnHeadersVisible = True Then
            myDataGridTableStyle1.ColumnHeadersVisible = False
            btnheader.Text = "Add Header"
         Else
            myDataGridTableStyle1.ColumnHeadersVisible = True
            btnheader.Text = "Remove Header"
         End If
      End Sub 'btnheader_Click