   Private Sub MyAddCustomDataTableStyle()
      ' Get the currency manager for 'myDataSet'.
      Dim myCurrencyManger As CurrencyManager = CType(Me.BindingContext(myDataSet), CurrencyManager)
      
      Dim myTableStyle As New DataGridTableStyle()
      myTableStyle.MappingName = "Customers"
      
      Dim proprtyDescriptorName As PropertyDescriptor = myCurrencyManger.GetItemProperties()("CustName")
      
      Dim myCustomerNameStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(proprtyDescriptorName)
      
      myCustomerNameStyle.MappingName = "custName"
      myCustomerNameStyle.HeaderText = "Customer Name"
      myTableStyle.GridColumnStyles.Add(myCustomerNameStyle)
      
      ' Add style for 'Date' column.
      Dim myDateDescriptor As PropertyDescriptor = myCurrencyManger.GetItemProperties()("Date")
      ' 'G' is for MM/dd/yyyy HH:mm:ss date format.
      Dim myDateStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myDateDescriptor, "G")
      
      myDateStyle.MappingName = "Date"
      myDateStyle.HeaderText = "Date"
      myDateStyle.Width = 150
      myTableStyle.GridColumnStyles.Add(myDateStyle)
      
      ' Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'MyAddCustomDataTableStyle
   
   