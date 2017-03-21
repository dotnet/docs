   Private Sub AddCustomDataTableStyle()
      Dim myTableStyle As New DataGridTableStyle()
      ' Map DataGridTableStyle to a DataTable.
      myTableStyle.MappingName = "Orders"
      ' Get CurrencyManager object.
      Dim myCurrencyManager As CurrencyManager = CType(BindingContext(myDataSet, "Orders"), CurrencyManager)
      ' Use the CurrencyManager to get the PropertyDescriptor for the column.
      Dim myPropertyDescriptor As PropertyDescriptor = myCurrencyManager.GetItemProperties()("Amount")
      ' Change the HeaderText.
      Dim myColumnStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myPropertyDescriptor, "c", True)
      ' Attach a event handler function with the 'HeaderTextChanged' event.
      AddHandler myColumnStyle.HeaderTextChanged, AddressOf MyHeaderText_Changed
      myColumnStyle.Width = 130
      myColumnStyle.HeaderText = "Amount in $"
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
      TablesAlreadyAdded = True
   End Sub 'AddCustomDataTableStyle

    Private Sub MyHeaderText_Changed(ByVal sender As Object, ByVal e As EventArgs)
        myLabel.Text = "Header Descriptor Property of DataGridColumnStyle has changed"
    End Sub 'MyHeaderText_Changed