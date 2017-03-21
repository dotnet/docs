    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TablesAlreadyAdded Then
            Return
        End If
        AddCustomDataTableStyle()
    End Sub 'myButton_Click

   Private Sub AddCustomDataTableStyle()
      Dim myTableStyle As New DataGridTableStyle()
      ' Map DataGridTableStyle to a DataTable.
      myTableStyle.MappingName = "Orders"
      ' Get CurrencyManager object.
      Dim myCurrencyManager As CurrencyManager = CType(BindingContext(myDataSet, "Orders"), CurrencyManager)
      ' Use the CurrencyManager to get the PropertyDescriptor for column.
      Dim myPropertyDescriptor As PropertyDescriptor = myCurrencyManager.GetItemProperties()("Amount")
      ' Construct a 'DataGridColumnStyle' object changing its format to 'Currency'.
      Dim myColumnStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myPropertyDescriptor, "c", True)
      ' Add EventHandler function for PropertyDescriptorChanged Event.
      AddHandler myColumnStyle.PropertyDescriptorChanged, AddressOf MyPropertyDescriptor_Changed
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      ' Add the DataGridTableStyle instance to the GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle)
      TablesAlreadyAdded = True
   End Sub 'AddCustomDataTableStyle

    Private Sub MyPropertyDescriptor_Changed(ByVal sender As Object, ByVal e As EventArgs)
        myLabel.Text = "Property Descriptor Property of DataGridColumnStyle has changed"
    End Sub 'MyPropertyDescriptor_Changed