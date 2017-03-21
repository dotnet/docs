
 Private Sub BindControl()
    Dim ds As DataSet
    ' Not shown: code to populate DataSet with tables.
    Text1.DataBindings.Add("Text", ds.Tables("Products"), "ProductName")
    Label1.DataBindings.Add("Text", ds.Tables("Suppliers"), "CompanyName")
    
 End Sub
       