Private Sub ContainsThisDataCol()
    Dim myPropertyDescriptor As PropertyDescriptor
    Dim myPropertyDescriptorCollection As PropertyDescriptorCOllection
    myPropertyDescriptorCollection = _
    me.BindingContext(DataSet1, "Customers").GetItemProperties()
    myPropertyDescriptor = myPropertyDescriptorCollection("FirstName")

    Dim myDataGridColumnStyle As DataGridColumnStyle
    myDataGridColumnStyle = DataGrid1.TableStyles(0). _
    GridColumnStyles(myPropertyDescriptor)
End Sub 